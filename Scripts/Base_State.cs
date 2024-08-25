using Godot;
using System;

public partial class Base_State : Node
{
    public State_Machine this_state_machine;
    
    public virtual void Handle_Input(InputEvent @event)
    {

    }

    public virtual void Handle_Process(double delta)
    {

    }

    public virtual void Enter_State()
    {
    }
}
