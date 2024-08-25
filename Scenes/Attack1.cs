using Godot;
using System;

public partial class Attack1 : Player_State_Base
{
    public override void _Ready()
    {
        AnimationPlayer ap = GetNode<AnimationPlayer>("../../AnimationPlayer");
        ap.AnimationFinished += End_state;
    }

    public override void Enter_State()
    {
        GetNode<AnimationPlayer>("../../AnimationPlayer").Play("Attack1");
    }
    
    public override void Handle_Process(double delta)
    {
        Apply_Gravity();
        Move_Left_Right();
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
