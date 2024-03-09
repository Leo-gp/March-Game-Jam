using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollideKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.Die();
        }
    }
}