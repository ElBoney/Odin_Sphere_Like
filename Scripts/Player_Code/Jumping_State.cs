using Godot;
using System;

public partial class Jumping_State : Player_State_Base
{
    public override void Enter_State()
    {
        y_velocity = 20;
    }

    public override void Handle_Process(double delta)
    {
        Apply_Gravity();
        Move_Left_Right();

        if(y_velocity <= 0)
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Falling"));
        }
    }
}
