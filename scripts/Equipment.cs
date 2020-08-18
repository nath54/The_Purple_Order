using System.Collections.Generic;
using Godot;
using System;

public class Equipment : Node
{

    // ############################# RESSOURCES : #############################
    public Dictionary<string, string> bodies_male=new Dictionary<string, string>(){
        {"white","res://player/spritesheets/body/male/man-white.tres"},
        {"black","res://player/spritesheets/body/male/man-black.tres"},
        {"brown","res://player/spritesheets/body/male/man-brown.tres"},
        {"olive","res://player/spritesheets/body/male/man-olive.tres"},
        {"peach","res://player/spritesheets/body/male/man-peach.tres"},
        {"dark","res://player/spritesheets/body/male/dark.tres"},
        {"dark2","res://player/spritesheets/body/male/dark2.tres"},
        {"tan","res://player/spritesheets/body/male/tanned2.tres"},
    };
    public Dictionary<string, string> bodies_female=new Dictionary<string, string>(){
        {"white","res://player/spritesheets/body/female/woman-white.tres"},
        {"black","res://player/spritesheets/body/female/woman-black.tres"},
        {"brown","res://player/spritesheets/body/female/woman-brown.tres"},
        {"olive","res://player/spritesheets/body/female/woman-olive.tres"},
        {"peach","res://player/spritesheets/body/female/woman-peach.tres"},
        {"dark","res://player/spritesheets/body/female/dark.tres"},
        {"dark2","res://player/spritesheets/body/female/dark2.tres"},
        {"tan","res://player/spritesheets/body/female/tanned2.tres"},
    };

    // ############################# VALEURS : #############################

    public bool is_player_female=false;
    public string player_body="white";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void act_player_equipement(Player p){
        AnimatedSprite an_body = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["body"]);
        if(an_body!=null){
            SpriteFrames sf_body=ResourceLoader.Load(bodies_male[player_body]) as SpriteFrames;
            if(is_player_female){ sf_body=ResourceLoader.Load(bodies_female[player_body]) as SpriteFrames; }
            an_body.Frames=sf_body;
        }

    }

}
