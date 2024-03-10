using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollideKiller : PlayerCollideBase
{
    protected override void OnPlayerCollided(PlayerController playerController)
    {
        playerController.Die();
    }
}