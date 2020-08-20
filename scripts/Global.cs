using System.Collections.Generic;
using Godot;
using System;

public class Global : Node
{
    public Langues langues;
    public Equipment equipment;
    public string langactu="fr";
    public List<string> saves= new List<string>();
    public Joystick_Button jb = null;
    public Sprite joystick = null;
    public MobileControls mobileControls = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        langues=(Langues)GetNode("/root/Langues");
        equipment=(Equipment)GetNode("/root/Equipment");
    }

    public void act_lang(){
        if(langues.langactu!=langactu){
            langues.chang_lang(langactu);
        }
        langues.act_textes();
    }

    public bool is_mobile(){
        string on = OS.GetName();
        List<string> mb = new List<string>(){"Android","iOS"};
        //return true; //debug on pc
        return mb.Contains(on);
    }



}
