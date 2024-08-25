using GD_NET_ScOUT;
using Godot;
using System;

[Test]
public partial class Player_Script_Test : Player_Character
{
    // [BeforeAll] public void Before_All()
    // {
    //     GetNode<State_Machine>("State_Machine");
    // }

    [Test] public void Test_State_Machine()
    {
        state_machine.Change_Current_State(GetNode<Base_State>("Player_States/Jumping"));
        Assert.AreSame(state_machine.current_state, GetNode<Base_State>("Player_States/Jumping"), "checks that state changes correctly");
        Assert.AreEqual<float>(Player_State_Base.y_velocity, 20, "the y_velocity is correct if passes");
    }
}
