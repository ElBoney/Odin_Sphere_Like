using System;
using Godot;

public partial class Whack_Me : CharacterBody3D
{
    float y_velocity = 0;
    float x_velocity = 0;
    [Export] float drag_coefficient = 1.5f;
    [Export] float gravity_increment = 0.2f;
    const float terminal_velocity = -20;

    public virtual void Apply_Gravity()
    {
        y_velocity -= gravity_increment;
        if (y_velocity < terminal_velocity)
        {
            y_velocity = terminal_velocity;
        }
    }

    public override void _Process(double delta)
    {
        if (!IsOnFloor())
        {
            Apply_Gravity();
        }

        x_velocity += -drag_coefficient * x_velocity * (float)delta;
        Velocity = new Vector3(x_velocity, y_velocity, 0);
        MoveAndSlide();

        if (Mathf.Abs(Position.X) > 10) { Position = Vector3.Zero; }
    }

    public void Get_Whacked(Vector2 sent_flying_to)
    {
        y_velocity = sent_flying_to.Y;
        x_velocity = sent_flying_to.X;
    }
}
