using Godot;

public partial class Up_Attack : Player_Attack_Base
{
    public override void Enter_State()
    {
        base.Enter_State();
        air_up_attacks_remaining--;
    }
}
