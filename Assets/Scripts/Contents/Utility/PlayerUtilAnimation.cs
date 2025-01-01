using UnityEngine;

public static class PlayerUtilAnimation
{
    public static readonly int hashDeath = Animator.StringToHash("Death");
    public static readonly int hashBlend = Animator.StringToHash("Blend");
    public static readonly int hashIdle = Animator.StringToHash("Idle");
    public static readonly int hashRespawn = Animator.StringToHash("Respawn");
    public static readonly int hashBaiscAttack = Animator.StringToHash("BaiscAttack");
    public static readonly int hashTimeoutToIdle = Animator.StringToHash("TimeoutToIdle");
    public static readonly int hashGrounded = Animator.StringToHash("Grounded");
    public static readonly int hashJump = Animator.StringToHash("Jump");

    public static readonly int hashJumpSpeed = Animator.StringToHash("JumpSpeed");
    public static readonly int hashMoveSpeed = Animator.StringToHash("MoveSpeed");
}
