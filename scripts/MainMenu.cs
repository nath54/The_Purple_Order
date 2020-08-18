using System.Collections.Generic;
using Godot;
using System;

public class MainMenu : Control
{
    public Global globale;
    public int id_bt_act=0;
    public List<string> bts=new List<string>(){
        "Buttons/VBoxContainer/Bt_continue",
        "Buttons/VBoxContainer/Bt_newgame",
        "Buttons/VBoxContainer/Bt_load",
        "Buttons/VBoxContainer/Bt_settings",
        "Buttons/VBoxContainer/Bt_quit",
    };

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        globale = (Global)GetNode("/root/Global");
        globale.act_lang();
        //
        Button bt_continue = (Button)GetNode("Buttons/VBoxContainer/Bt_continue");
        if(globale.saves.Count==0){
            bt_continue.Visible=false;
            bts.RemoveAt(0);
            GD.Print(bts);
        }
        //
        Button b = (Button)GetNode(bts[id_bt_act]);
        b.WarpMouse(b.RectPosition+b.RectSize/2);
    }
    
    public override void _Input(InputEvent @event){
        if(Input.IsActionJustPressed("menu")){
            _on_Bt_quit_pressed();
        }

        if(Input.IsActionJustPressed("move_up")){
            if(id_bt_act>0){
                id_bt_act-=1;
                Button b = (Button)GetNode(bts[id_bt_act]);
                b.WarpMouse(b.RectSize/2);
            }
        }
        if(Input.IsActionJustPressed("move_down")){
            if(id_bt_act<bts.Count-1){
                id_bt_act+=1;
                Button b = (Button)GetNode(bts[id_bt_act]);
                b.WarpMouse(b.RectSize/2);
            }
        }
        if(Input.IsActionJustPressed("ui_accept") || Input.IsActionJustPressed("action")){
            Button b = (Button)GetNode(bts[id_bt_act]);
            b.EmitSignal("pressed");
        }

    }

    public void _on_Bt_continue_pressed(){

    }

    public void _on_Bt_newgame_pressed(){
        GetTree().ChangeScene("res://maps/Island1.tscn");
    }

    public void _on_Bt_load_pressed(){

    }

    public void _on_Bt_settings_pressed(){

    }

    public void on_credits(){

    }

    public void _on_Bt_quit_pressed(){
        GetTree().Quit();
    }

}
