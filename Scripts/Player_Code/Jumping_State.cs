using Godot;
using System;

public partial class Jumping_State : Player_State_Base
{
    [Export] float jump_hight = 6;
    [Export] float jump_duration = 0.5f;
    float Jump_Velocity { get { return 2 * jump_hight / jump_duration; } }
    float Jump_Gravity { get { return 2 * jump_hight / (jump_duration * jump_duration); } }
    public override void Enter_State()
    {
        y_velocity = Jump_Velocity;
    }

    public override void Handle_Process(double delta)
    {
        //Apply_Gravity();
        y_velocity -= Jump_Gravity * (float)delta;
        Move_Left_Right();

        if (y_velocity <= 0)
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Falling"));
        }
    }
    public override void Handle_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("Attack"))
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Attack_One"));
        };
    }
}
