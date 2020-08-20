using Godot;
using System;

public class MobileControls : Control
{
    public Global globale;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        globale=(Global)GetNode("/root/Global");
        Joystick_Button jb = (Joystick_Button)GetNode("joystick/Joystick_Button");
        globale.jb=jb;
        Sprite global_joystick = (Sprite)GetNode("joystick");
        globale.joystick=global_joystick;
        globale.mobileControls=this;
        if(!globale.is_mobile()){
            Visible=false;
        }
    }
}
