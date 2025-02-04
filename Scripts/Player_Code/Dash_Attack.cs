using Godot;
using System;

public partial class Dash_Attack : Player_Attack_Base
{
    [Export] Vector2 dash_velocity = new Vector2();

    public override void Enter_State()
    {
        base.Enter_State();
        dashes_remaining--;
    }

    public override void Handle_Process(double delta)
    {
        player_.Velocity = new Vector3(dash_velocity.X * player_.facing_direction, dash_velocity.Y, 0);
        player_.MoveAndSlide();
    }
}
