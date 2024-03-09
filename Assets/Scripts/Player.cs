using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilter2D groundFilter;

    private bool _isJumping;

    private Rigidbody2D _rb;

    private bool IsGrounded => _rb.IsTouching(groundFilter);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
        }

        // Test only
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPosition();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    public void Die()
    {
        ResetPosition();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
    }

    private void Jump()
    {
        if (_isJumping && IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _isJumping = false;
    }

    private void ResetPosition()
    {
        _rb.position = Vector2.zero;
        _rb.velocity = Vector2.zero;
    }
}