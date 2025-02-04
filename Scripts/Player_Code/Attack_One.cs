using Godot;
using System;

public partial class Attack_One : Player_Attack_Base
{
    public override void Enter_State()
    {
        base.Enter_State();
        y_velocity = 0;
    }
    public override void Handle_Process(double delta)
    {
        //Apply_Gravity();
        Dash_Attack_Option();
        Move_Left_Right();
    }

    public override void Handle_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("Attack"))
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Attack_Two"));
        }
    }


}
