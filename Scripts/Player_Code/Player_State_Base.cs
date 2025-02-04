using Godot;
using System;
using System.Collections.Generic;

public partial class Player_State_Base : Base_State
{
    public Player_Character player_;
    public float player_base_speed = 10;
    public static float y_velocity = 0;
    public float gravity_increment = 0.2f;
    public const float terminal_velocity = -20;
    [Export] protected Player_State state_name;
    protected static Dictionary<Player_State, Player_State_Base> states = new Dictionary<Player_State, Player_State_Base>();
    public enum Player_State
    {
        Grounded,
        Falling,
        Jumping,
        Attack_One,
        Attack_Two,
        Attack_Three,
        Up_Attack,
        Dash_Attack
    }

    public override void _Ready()
    {
        states.Add(state_name, this);
    }

    public virtual void Move_Left_Right()
    {
        float move_lr = Input.GetAxis("Move_Left", "Move_Right");
        Vector3 velocity_ = new Vector3(move_lr * player_base_speed, y_velocity, 0);
        player_.Velocity = velocity_;
        player_.MoveAndSlide();
    }

    public virtual void Apply_Gravity()
    {
        y_velocity -= gravity_increment;
        if(y_velocity < terminal_velocity)
        {
            y_velocity = terminal_velocity;
        }
    }

    protected void Universal_Attack_Options()
    {
        if(Input.IsActionJustPressed("Attack"))
        {
            if(Input.IsActionPressed("Up_Button"))
            {
                this_state_machine.Change_Current_State(states[Player_State.Up_Attack]);
                return;
            }
            this_state_machine.Change_Current_State(states[Player_State.Attack_One]);
        }
    }

    protected void Dash_Attack_Option()
    {
        if(Input.IsActionPressed("Attack") && Mathf.Abs(Input.GetAxis("Move_Left", "Move_Right")) > 0.1f)
        { this_state_machine.Change_Current_State(states[Player_State.Dash_Attack]);}
    }

}
