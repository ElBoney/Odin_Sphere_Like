using System.Collections.Generic;
using Godot;

public partial class Player_Character : CharacterBody3D
{
    public State_Machine state_machine;
    public Area3D hitbox;
    public int facing_direction = 1;

    public override void _Ready()
    {
        hitbox = GetNode<Area3D>("Hitbox");
        UpDirection = Vector3.Up;
        state_machine = GetNode<State_Machine>("State_Machine");
        List<Player_State_Base> list_states = new List<Player_State_Base>();
        foreach (Player_State_Base s in GetNode<Node>("Player_States").GetChildren())
        {
            s.player_ = this;
            s.this_state_machine = state_machine;
            list_states.Add(s);
        }

        state_machine.Change_Current_State(list_states[1]);
    }

    public override void _Input(InputEvent @event)
    {
        state_machine.Pass_Input(@event);

        //↓ TODO: revise the way this happens (put in into the states too)
        // if (@event.IsActionPressed("Move_Right"))
        // {
        //     facing_direction = 1;
        //     //hitbox.Position = new Vector3(1,0,0);
        // }
        // else if (@event.IsActionPressed("Move_Left"))
        // {
        //     facing_direction = -1;
        //     //hitbox.Position = new Vector3(-1,0,0);
        // }
        // Scale = new Vector3(facing_direction, 1,1);
    }

    public override void _PhysicsProcess(double delta)
    {
        state_machine.Pass_Process(delta);
    }

    public void Hit_Something(Node3D colliding_body)
    {
        state_machine.Pass_Collision(colliding_body);
    }
}
