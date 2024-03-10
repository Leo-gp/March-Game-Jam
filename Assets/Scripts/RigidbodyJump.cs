using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilterConfig groundFilterConfig;

    private Rigidbody2D _rb;

    private bool IsGrounded => _rb.IsTouching(groundFilterConfig.ContactFilter);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}