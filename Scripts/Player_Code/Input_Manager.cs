using Godot;
public partial class Input_Manager : Node
{
    public bool is_attack_held = false;
    float hold_time_target = 0.15f;
    float held_time = 0;

    public override void _Process(double delta)
    {
        if(Input.IsActionPressed("Attack"))
        {
            held_time += (float)delta;
        }
        else{held_time = 0;}

        if(held_time > hold_time_target){is_attack_held = true;}
        else {is_attack_held = false;}
    }
}