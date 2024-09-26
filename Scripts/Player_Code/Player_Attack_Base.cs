using Godot;
using System;

public partial class Player_Attack_Base : Player_State_Base
{
    [Export] protected string attack_name = "Attack_One";
    [Export] protected Vector2 Knockback = new Vector2(0, 10);

    public override void _Ready()
    {
        AnimationPlayer ap = GetNode<AnimationPlayer>("../../AnimationPlayer");
        ap.AnimationFinished += End_state;
    }

    public override void Enter_State()
    {
        GetNode<AnimationPlayer>("../../AnimationPlayer").Play(attack_name);
    }
    
    public override void State_Collision(Node3D colliding_body)
    {
        if(colliding_body is Whack_Me whacked)
        {
            whacked.Get_Whacked(Knockback);
        }
    }

    public void End_state(StringName anim_name)
    {
        if(player_.IsOnFloor())
        {
        this_state_machine.Change_Current_State(GetNode<Base_State>("../Grounded"));
        return;
        }
        this_state_machine.Change_Current_State(GetNode<Base_State>("../Falling"));
    }
}
