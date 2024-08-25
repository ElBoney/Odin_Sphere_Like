using Godot;
using System;

public partial class State_Machine : Node
{

    public Base_State current_state {get; private set;}

    public void Change_Current_State(Base_State new_state)
    {
        current_state = new_state;
        current_state.Enter_State();
    }
    
    public void Pass_Input(InputEvent @event)
    {
        current_state.Handle_Input(@event);
    }

    public void Pass_Process(double delta)
    {
        current_state.Handle_Process(delta);
    }

}