using UnityEngine;

public class PlayerCollideRepeller : PlayerCollideBase
{
    [SerializeField] private Vector2 repulsionForce;

    protected override void OnPlayerCollided(Player player)
    {
        player.Rb.velocity = Vector2.zero;
        player.Rb.AddForce(repulsionForce, ForceMode2D.Impulse);
    }
}