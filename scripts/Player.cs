using System.Collections.Generic;
using Godot;
using System;

public class Player : KinematicBody2D
{
    //Name : 
    public string name = "pseudo";
    //Speed
    private float _walkSpeed = 100;
    private float _runSpeed = 250;
    //Life :
    public int life_tot = 100;
    public int life_act = 100;
    //Energy : 
    public int energy_tot = 100;
    public int energy_act = 100;
    public bool is_running = false;
    //Orientation
    public string orientation = "right";
    //Gestion de Sprites : 
    public AnimatedSprite animatedSprite;
    public string current_animation="move_left";
    public bool animation_playing=false;
    public Dictionary<string, string> equipment_act = new Dictionary<string, string>(){
        {"accessory","Sprites/accessory"},
        {"arm","Sprites/arm"},
        {"behind_body","Sprites/behind_body"},
        {"belt","Sprites/belt"},
        {"body","Sprites/body"},
        {"facial","Sprites/facial"},
        {"feet","Sprites/feet"},
        {"hair","Sprites/hair"},
        {"hand","Sprites/hand"},
        {"head","Sprites/head"},
        {"leg","Sprites/leg"},
        {"shoulder","Sprites/shoulder"},
        {"torso","Sprites/torso"},
        {"weapon","Sprites/weapon"},
    };

    //POUR MOBILE
    public double[] joystick_val={0.0,0.0};

    //AUTRE
    public Global globale;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //
        globale = (Global)GetNode("/root/Global");
        //
        //act_equipment();
        //
        set_anim("move_left");
        set_anim_frame(0);
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
        MoveAndCollide(velocity);
        //
    }


    public void act_equipment(){
        globale.equipment.act_player_equipement(this);
    }    

    public void set_anim(string aname){
        foreach(string san in equipment_act.Values){
            animatedSprite=(AnimatedSprite)GetNode(san);
            if(animatedSprite!=null && animatedSprite.Frames!=null){
                
                    animatedSprite.Animation=aname;
                
            }            
        }
    }
    public void play_anim(string aname){
        foreach(string san in equipment_act.Values){
            animatedSprite=(AnimatedSprite)GetNode(san);
            if(animatedSprite!=null && animatedSprite.Frames!=null){
                animatedSprite.Play();
            }            
        }
    }
    public void stop_anim(string aname){
        foreach(string san in equipment_act.Values){
            animatedSprite=(AnimatedSprite)GetNode(san);
            if(animatedSprite!=null && animatedSprite.Frames!=null){
                animatedSprite.Stop();
            }            
        }
    }
    public void set_anim_frame(int frame){
        foreach(string san in equipment_act.Values){
            animatedSprite=(AnimatedSprite)GetNode(san);
            if(animatedSprite!=null && animatedSprite.Frames!=null){                
                animatedSprite.Frame=frame;
            }            
        }
    }
    public void set_anim_speedscale(int speedscale){
        foreach(string san in equipment_act.Values){
            animatedSprite=(AnimatedSprite)GetNode(san);
            if(animatedSprite!=null && animatedSprite.Frames!=null){                
                animatedSprite.SpeedScale=speedscale;
            }            
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
