using System.Collections.Generic;
using Godot;
using System;

public class PersoCreation : Control
{
    

    //BUTTONS NAVIGATION
    public List<string> buttons=new List<string>(){
        "ViewPort",
        "Parameters/C_Gender/bt_normal",
        "Parameters/C_skin/bt_normal",
        "Parameters/C_hairs/bt_normal",
        "Parameters/C_eyes/bt_normal",
        "Parameters/Bt_next"
    };
    public List<List<string>> bts_parameters = new List<List<string>>(){
        new List<string>(){ "Parameters/C_Gender/bt_normal/LeftButton","Parameters/C_Gender/bt_normal/RightButton" },
        new List<string>(){ "Parameters/C_skin/bt_normal/LeftButton","Parameters/C_skin/bt_normal/RightButton" },
        new List<string>(){ "Parameters/C_hairs/bt_normal/LeftButton","Parameters/C_hairs/bt_normal/RightButton" },
        new List<string>(){ "Parameters/C_eyes/bt_normal/LeftButton","Parameters/C_eyes/bt_normal/RightButton" }
    };
    public int id_bt_act=0;

    //
    public Global globale;
    public Player player;
    public bool player_moving=false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //
        globale=(Global)GetNode("/root/Global");
        //
        player=(Player)GetNode("ViewPort/Player");
        mouse_exited_viewport();
        //
    }

    public void mouse_enter_viewport(){
        player_moving=true;
        player.SetProcessInput(true);
        player.SetPhysicsProcess(true);
        Label l = (Label)GetNode("ViewPort/Inf_exit");
        l.Visible=true;
    }
    public void mouse_exited_viewport(){
        player_moving=false;
        player.SetProcessInput(false);
        player.SetPhysicsProcess(false);
        Label l = (Label)GetNode("ViewPort/Inf_exit");
        l.Visible=false;
    }

    public override void _Input(InputEvent @event){
        if(!player_moving){
            if(Input.IsActionJustPressed("move_up")){
                if(id_bt_act>0){
                    id_bt_act--;
                    if(id_bt_act==0){
                        Control v = (Control)GetNode("ViewPort");
                        Godot.Rect2 r = v.GetRect();
                        v.WarpMouse(r.Size/2);
                    }
                    if(id_bt_act>=1 && id_bt_act<=4){
                        TextureButton bt = (TextureButton)GetNode(bts_parameters[id_bt_act-1][0]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                    else if(id_bt_act==5){
                        Button bt = (Button)GetNode(buttons[id_bt_act]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                }
            }
            if(Input.IsActionJustPressed("move_down")){
                if(id_bt_act<buttons.Count-1){
                    id_bt_act++;
                    if(id_bt_act==0){
                        Control v = (Control)GetNode("ViewPort");
                        Godot.Rect2 r = v.GetRect();
                        v.WarpMouse(r.Size/2);
                    }
                    if(id_bt_act>=1 && id_bt_act<=4){
                        TextureButton bt = (TextureButton)GetNode(bts_parameters[id_bt_act-1][0]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                    else if(id_bt_act==5){
                        Button bt = (Button)GetNode(buttons[id_bt_act]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                }
            }
            if(Input.IsActionJustPressed("move_left")){
                if(id_bt_act>=1 && id_bt_act<=4){
                    TextureButton bt = (TextureButton)GetNode(bts_parameters[id_bt_act-1][0]);
                    bt.EmitSignal("pressed");
                    bt.WarpMouse(bt.RectSize/2);
                }
            }if(Input.IsActionJustPressed("move_right")){
                if(id_bt_act>=1 && id_bt_act<=4){
                    TextureButton bt = (TextureButton)GetNode(bts_parameters[id_bt_act-1][1]);
                    bt.EmitSignal("pressed");
                    bt.WarpMouse(bt.RectSize/2);
                }
            }
        }
        else{
            if(Input.IsActionJustPressed("menu")){
                mouse_exited_viewport();
            }
        }
    }


}
