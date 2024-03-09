using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollideKiller : PlayerCollideBase
{
    protected override void OnPlayerCollided(Player player)
    {
        player.Die();
    }
}