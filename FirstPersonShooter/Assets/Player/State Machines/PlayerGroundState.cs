using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    //Ground State Variables
    public float max_speed = 6f;
    public float acceleration = 60f;
    public float stop_speed = 0.5f;
    public float jump_impulse = 10f;
    public float friction = 4f;

    public override void EnterState(PlayerStateMachine stateMachine)
    {
        
    }
    public override void ExitState(PlayerStateMachine stateMachine)
    {
      
    }
    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        
    }
    public override void FixedUpdateState(PlayerStateMachine stateMachine)
    {
        //Set Velocity
        stateMachine.player_velocity = MoveGround(stateMachine.wish_dir, stateMachine.player_velocity);

        //Switch States
        if (!stateMachine.character_controller.isGrounded)
        {
            stateMachine.SwitchState(this, stateMachine.air_state);
        }
        if (stateMachine.jump_button_pressed)
        {
            stateMachine.player_velocity.y = jump_impulse;
            stateMachine.SwitchState(this, stateMachine.air_state);
        }
    }

    private Vector3 MoveGround(Vector3 wish_dir, Vector3 current_velocity)
    {
        //Create new velocity vector
        Vector3 new_velocity = new Vector3(current_velocity.x, 0, current_velocity.z); //Remove y component

        //Since on ground, apply friction
        float speed = new_velocity.magnitude;
        if (speed <= stop_speed)
        {
            new_velocity = Vector3.zero;
            speed = 0;

        }
        if (speed != 0)
        {
            float drop = speed * friction * Time.deltaTime;
            new_velocity *= Mathf.Max(speed - drop, 0) / speed; //Scale velocity based on friction

        }
        new_velocity = new Vector3(new_velocity.x, current_velocity.y, new_velocity.z); //Add y component back in

        return Accelerate(wish_dir, new_velocity, acceleration, max_speed);
    }
}
