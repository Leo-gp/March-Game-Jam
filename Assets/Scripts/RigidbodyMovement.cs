using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalMove)
    {
        _rb.velocity = new Vector2(horizontalMove * moveSpeed, _rb.velocity.y);
    }
}