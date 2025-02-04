using Godot;
using System;

public partial class Attack_Three : Player_Attack_Base
{

    public override void Handle_Process(double delta)
    {
        base.Handle_Process(delta);
        Dash_Attack_Option();
    }
}
