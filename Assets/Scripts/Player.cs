using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilter2D groundFilter;
    [SerializeField] private Vector2 resetPosition;

    private bool _isJumping;

    public Rigidbody2D Rb { get; private set; }

    private bool IsGrounded => Rb.IsTouching(groundFilter);

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
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
        Rb.velocity = new Vector2(moveSpeed, Rb.velocity.y);
    }

    private void Jump()
    {
        if (_isJumping && IsGrounded)
        {
            Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _isJumping = false;
    }

    private void ResetPosition()
    {
        Rb.position = resetPosition;
        Rb.velocity = Vector2.zero;
    }
}