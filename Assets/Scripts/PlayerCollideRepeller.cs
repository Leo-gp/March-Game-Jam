using UnityEngine;

public class PlayerCollideRepeller : PlayerCollideBase
{
    [SerializeField] private Vector2 repulsion;

    protected override void OnPlayerCollided(PlayerController playerController)
    {
        playerController.Repel(repulsion);
    }
}