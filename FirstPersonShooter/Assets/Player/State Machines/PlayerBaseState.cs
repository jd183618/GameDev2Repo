using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateMachine stateMachine);
    public abstract void ExitState(PlayerStateMachine stateMachine);
    public abstract void UpdateState(PlayerStateMachine stateMachine);
    public abstract void FixedUpdateState(PlayerStateMachine stateMachine);

    public Vector3 Accelerate(Vector3 wish_dir, Vector3 current_velocity, float accel, float max_speed)
    {
        //Vector 3 projection of current velocity onto wish dir. The speed the player is going
        float proj_speed = Vector3.Dot(current_velocity, wish_dir);
        float accel_speed = accel * Time.deltaTime;

        //Truncate accelerated velocity if needed.
        if (proj_speed + accel_speed > max_speed)
        {
            accel_speed = max_speed - proj_speed;
        }

        //Return new speed.
        return current_velocity + (wish_dir * accel_speed);
    }
}
