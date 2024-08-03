using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var velocity = character.Rigidbody.velocity;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            state = Movement.MovementState.Run;
        }
        if (Input.GetButtonDown("Jump") && movement.OnGround)
        {
            movement.Jump(movement.JumpForce);
            state = Movement.MovementState.Jump;
        }
        if (velocity.y < -0.01f)
        {
            state = Movement.MovementState.Fall;
        }

        animator.SetInteger("State", (int)state);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
