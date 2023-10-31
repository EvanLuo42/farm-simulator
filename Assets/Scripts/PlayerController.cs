using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public float moveSpeed;
    private static readonly int IsMoving = Animator.StringToHash("Is Moving");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal") * Vector2.right
                         + Input.GetAxisRaw("Vertical") * Vector2.up;

        if (_moveDirection == Vector2.zero)
        {
            _animator.SetBool(IsMoving, false);
            return;
        }

        _moveDirection = _moveDirection.normalized;
        _animator.SetBool(IsMoving, true);
        _animator.SetFloat(Horizontal, _moveDirection.x);
        _animator.SetFloat(Vertical, _moveDirection.y);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * Time.fixedDeltaTime * moveSpeed);
    }
}
