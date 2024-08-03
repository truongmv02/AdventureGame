using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : StateMachineBehaviour
{
    protected Character character;
    protected Movement movement;
    protected Movement.MovementState state;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character = GameManager.Instance.Character;
        movement = character.Movement;
        state = (Movement.MovementState)animator.GetInteger("State");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
