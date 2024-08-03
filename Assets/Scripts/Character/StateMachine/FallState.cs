using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : CharacterState
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var velocity = character.Rigidbody.velocity;
        if (Input.GetButtonDown("Jump") && movement.JumpCount == 1)
        {
            movement.Jump(movement.DoubleJumpForce);
            state = Movement.MovementState.DoubleJump;
            animator.SetInteger("State", (int)state);
        }

        if (movement.OnGround)
        {
            state = Movement.MovementState.Idle;
            animator.SetInteger("State", (int)state);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
