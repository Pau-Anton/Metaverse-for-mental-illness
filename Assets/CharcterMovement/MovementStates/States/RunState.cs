using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Running", true); //blend tree activator
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (movement.vInput < 0 ) movement.currentMoveSpeed = movement.runBackSpeed; //going backwards
        else movement.currentMoveSpeed = movement.runSpeed; //going forward
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
