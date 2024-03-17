using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool disableFacingDirectionChange;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalMove)
    {
        _rb.velocity = new Vector2(horizontalMove * moveSpeed, _rb.velocity.y);
        UpdateFacingDirection();
    }

    private void UpdateFacingDirection()
    {
        if (disableFacingDirectionChange)
        {
            return;
        }
        var desiredYAngle = _rb.velocity.x > 0 ? 0f : _rb.velocity.x < 0 ? 180f : transform.eulerAngles.y;
        var t = transform;
        var eulerAngles = t.eulerAngles;
        eulerAngles = new Vector3(eulerAngles.x, desiredYAngle, eulerAngles.z);
        t.eulerAngles = eulerAngles;
    }
}