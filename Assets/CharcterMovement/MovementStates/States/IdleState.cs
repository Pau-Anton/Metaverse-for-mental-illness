using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {

    }

    public override void UpdateState(MovementStateManager movement)
    {   
        if(movement.blocked==true){
            if(movement.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
                movement.blocked=false;
            }
        }        
        else if (movement.dir.magnitude > 0.1f)//if moving 
        {
            if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            else movement.SwitchState(movement.Walk);
        }

        if (Input.GetKeyDown(KeyCode.C) && movement.enableSit) movement.SwitchState(movement.Sit);
        if (Input.GetKeyDown(KeyCode.E) && movement.enableOpen) movement.SwitchState(movement.Open);
        
    }
}
