using Godot;
using System;

public class Player : KinematicBody2D
{
    //Name : 
    public string name = "pseudo";
    //Speed
    private float _walkSpeed = 30;
    private float _runSpeed = 50;
    //Life :
    public int life_tot = 100;
    public int life_act = 100;
    //Energy : 
    public int energy_tot = 100;
    public int energy_act = 100;
    public bool is_running = false;
    //Equipement : 
    public struct equipement{
    };
    //Orientation
    public string orientation = "right";
    //Gestion de Sprites : 

    //POUR MOBILE
    public double[] joystick_val={0.0,0.0};

    //AUTRE
    public Global globale;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //
        globale = (Global)GetNode("/root/Global");
    }

    public override void _PhysicsProcess(float delta){
        Vector2 velocity=new Vector2(0,0);
        float vit = _walkSpeed;
        if(is_running){ vit=_runSpeed; }
        vit*=delta;
        if(Input.IsActionPressed("move_up")){
            velocity.y-=vit;
        }
        if(Input.IsActionPressed("move_down")){
            velocity.y+=vit;
        }
        if(Input.IsActionPressed("move_left")){
            velocity.x-=vit;
        }
        if(Input.IsActionPressed("move_right")){
            velocity.x+=vit;
        }
        //
        
    }
    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
