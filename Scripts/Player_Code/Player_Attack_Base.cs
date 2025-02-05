using Godot;
using System;

public partial class Player_Attack_Base : Player_State_Base
{
    [Export] protected string attack_name = "Attack_One";
    [Export] protected Vector2 Knockback = new Vector2(0, 3);

    public override void _Ready()
    {
        base._Ready();
        AnimationPlayer ap = GetNode<AnimationPlayer>("../../AnimationPlayer");
        ap.AnimationFinished += End_state;
    }

    public override void Enter_State()
    {
        player_.hitbox.Monitoring = false;
        GetNode<AnimationPlayer>("../../AnimationPlayer").Play(attack_name);
        Turn_Around();
    }
    
    public override void State_Collision(Node3D colliding_body)
    {
        if(colliding_body is Whack_Me whacked)
        {
            Vector2 corrected_knockback = new Vector2(Knockback.X * player_.facing_direction, Knockback.Y);
            whacked.Get_Whacked(corrected_knockback);
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
