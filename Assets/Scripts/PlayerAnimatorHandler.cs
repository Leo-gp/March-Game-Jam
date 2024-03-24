using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorHandler : MonoBehaviour
{
    private static readonly int IsWalkingParam = Animator.StringToHash("IsWalking");
    private static readonly int IsGroundedParam = Animator.StringToHash("IsGrounded");

    private Animator _animator;
    private RigidbodyJump _rbJump;
    private RigidbodyMovement _rbMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rbMovement = GetComponent<RigidbodyMovement>();
        _rbJump = GetComponent<RigidbodyJump>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalkingParam, _rbMovement is { IsMoving: true });
        _animator.SetBool(IsGroundedParam, _rbJump is { IsGrounded: true });
    }
}