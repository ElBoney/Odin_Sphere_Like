using Godot;
using System;

public partial class Falling_State : Player_State_Base
{
    public override void Handle_Process(double delta)
    {
        Apply_Gravity();
        Move_Left_Right();

        if(player_.IsOnFloor())
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Grounded"));
        }
    }

}
