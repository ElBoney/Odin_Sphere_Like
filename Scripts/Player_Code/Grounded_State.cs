using Godot;
using System;

public partial class Grounded_State : Player_State_Base
{

    public override void Enter_State()
    {
        y_velocity = -0.1f;
    }

    public override void Handle_Process(double delta)
    {
        Move_Left_Right();

        if(!player_.IsOnFloor())
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Falling"));
        }
    }

    public override void Handle_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("Jump"))
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Jumping"));
        }
        if(@event.IsActionPressed("Attack"))
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Attack1"));
        }
    }
}
