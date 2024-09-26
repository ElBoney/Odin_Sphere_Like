using Godot;
using System;

public partial class Attack_Two : Player_Attack_Base
{
    public override void Handle_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("Attack"))
        {
            this_state_machine.Change_Current_State(GetNode<Base_State>("../Attack_Three"));
        }
    }
}
