using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterState
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float direction = Input.GetAxisRaw("Horizontal");
        var velocity = character.Rigidbody.velocity;
        if (direction == 0)
        {
            state = Movement.MovementState.Idle;
        }

        if (Input.GetButtonDown("Jump") && movement.OnGround)
        {
            movement.Jump(movement.JumpForce);
            state = Movement.MovementState.Jump;
        }

        if (velocity.y < -0.1f)
        {
            state = Movement.MovementState.Fall;
        }

        animator.SetInteger("State", (int)state);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
