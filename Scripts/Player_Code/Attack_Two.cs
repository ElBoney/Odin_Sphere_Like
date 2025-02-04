using Godot;
using System;

public partial class Attack_Two : Player_Attack_Base
{
    public override void Handle_Process(double delta)
    {
        base.Handle_Process(delta);
        Dash_Attack_Option();
    }
    public override void Handle_Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Attack"))
        {
            if (Input.IsActionPressed("Up_Button") && air_up_attacks_remaining > 0)
            {
                this_state_machine.Change_Current_State(states[Player_State.Up_Attack]);
                return;
            }
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Attack_Three"));
        }
    }
}
