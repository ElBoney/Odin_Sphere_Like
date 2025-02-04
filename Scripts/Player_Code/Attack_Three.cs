using Godot;
using System;

public partial class Attack_Three : Player_Attack_Base
{

    public override void Handle_Process(double delta)
    {
        base.Handle_Process(delta);
        Dash_Attack_Option();
        if (Input.IsActionPressed("Up_Button") && Input.IsActionJustPressed("Attack") && air_up_attacks_remaining > 0)
        {
            this_state_machine.Change_Current_State(states[Player_State.Up_Attack]);
        }
    }
}
