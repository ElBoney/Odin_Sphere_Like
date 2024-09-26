using Godot;

public partial class Whack_Me : CharacterBody3D
{
    float y_velocity = 0;
    float x_velocity = 0;
    float gravity_increment = 0.5f;
    const float terminal_velocity = -20;

    public virtual void Apply_Gravity()
    {
        y_velocity -= gravity_increment;
        if(y_velocity < terminal_velocity)
        {
            y_velocity = terminal_velocity;
        }
    }

    public override void _Process(double delta)
    {
        if(!IsOnFloor())
        {
            Apply_Gravity();
        }

        x_velocity = Mathf.Lerp(x_velocity, 0, 0.05f);
        Velocity = new Vector3(x_velocity, y_velocity, 0);
        MoveAndSlide();
    }

    public void Get_Whacked(Vector2 sent_flying_to)
    {
        y_velocity = sent_flying_to.Y;
        x_velocity = sent_flying_to.X;
    }
}
