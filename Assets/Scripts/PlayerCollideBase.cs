using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class PlayerCollideBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            OnPlayerCollided(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            OnPlayerCollided(player);
        }
    }

    protected abstract void OnPlayerCollided(PlayerController playerController);
}