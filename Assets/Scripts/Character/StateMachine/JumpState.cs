using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : CharacterState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        movement.JumpCount++;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 velocity = character.Rigidbody.velocity;

        if (movement.OnGround)
        {
            state = Movement.MovementState.Idle;
        }

        if (velocity.y < -0.01f)
        {
            state = Movement.MovementState.Fall;    
        }

        if (Input.GetButtonDown("Jump") && movement.JumpCount == 1)
        {
            movement.Jump(movement.DoubleJumpForce);
            state = Movement.MovementState.DoubleJump;
        }
        animator.SetInteger("State", (int)state);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
