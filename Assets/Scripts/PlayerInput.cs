using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalMove { get; private set; }
    public bool IsJumping { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        IsJumping = Input.GetButtonDown("Jump");
    }
}