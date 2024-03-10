using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(RigidbodyMovement))]
[RequireComponent(typeof(RigidbodyJump))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 resetPosition;

    private bool _isJumping;

    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private RigidbodyJump _rbJump;
    private RigidbodyMovement _rbMovement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _rbMovement = GetComponent<RigidbodyMovement>();
        _rbJump = GetComponent<RigidbodyJump>();
    }

    private void Update()
    {
        if (_playerInput.IsJumping)
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

    public void Repel(Vector2 repulsion)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(repulsion, ForceMode2D.Impulse);
    }

    private void Move()
    {
        _rbMovement.Move(_playerInput.HorizontalMove);
    }

    private void Jump()
    {
        if (_isJumping)
        {
            _rbJump.Jump();
        }

        _isJumping = false;
    }

    private void ResetPosition()
    {
        _rb.position = resetPosition;
        _rb.velocity = Vector2.zero;
    }
}