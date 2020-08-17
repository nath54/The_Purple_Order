using Godot;
using System;

public class MainMenu : Control
{
    public Global globale;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        globale = (Global)GetNode("/root/Global");
        globale.act_lang();
        //
        Button bt_continue = (Button)GetNode("Buttons/VBoxContainer/Bt_continue");
        if(globale.saves.Count==0){
            bt_continue.Visible=false;
        }
    }

}
