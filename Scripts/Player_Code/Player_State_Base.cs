using Godot;
using System;

public partial class Player_State_Base : Base_State
{
    public Player_Character player_;
    public float player_base_speed = 10;
    public static float y_velocity = 0;
    public float gravity_increment = 0.5f;
    public const float terminal_velocity = -20;

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

}
