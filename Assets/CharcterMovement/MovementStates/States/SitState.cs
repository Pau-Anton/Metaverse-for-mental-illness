using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitState : MovementBaseState
{ //
    public override void EnterState(MovementStateManager movement)
    {   
         movement.anim.SetTrigger("Sit"); //activates stand to sit animation
         movement.anim.SetBool("Sitting", true); //enables sitting
         movement.blocked=true;
    }

    public override void UpdateState(MovementStateManager movement)
    {   
        if (Input.GetKey(KeyCode.C) && movement.anim.GetCurrentAnimatorStateInfo(0).IsName("SittingIdle")) 
        ExitState(movement, movement.Idle); //exit sitting by pressing C again       
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Sitting", false);
        movement.SwitchState(state);
    }

}
