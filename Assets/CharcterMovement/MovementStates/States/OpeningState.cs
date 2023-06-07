using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningState : MovementBaseState
{   
    public override void   EnterState(MovementStateManager movement)
    {  
        movement.anim.SetTrigger("Open"); //activates open animation
        movement.blocked=true;
    }

    public override void UpdateState(MovementStateManager movement)
    {   
        if (!movement.anim.GetCurrentAnimatorStateInfo(0).IsName("Open") &&
            !movement.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")&&
            !movement.anim.GetCurrentAnimatorStateInfo(0).IsName("Walking")) 
             movement.SwitchState(movement.Idle); //exits when opening animation is done
        
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.SwitchState(state);
    }

}
