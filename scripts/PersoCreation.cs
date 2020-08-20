using System.Linq;
using System.Collections.Generic;
using Godot;
using System;

public class PersoCreation : Control
{
    public int[] bts_2={1,2,3,5};

    //BUTTONS NAVIGATION
    public List<string> buttons=new List<string>(){
        "ViewPort",
        "Parameters/C_Gender/bt_normal",
        "Parameters/C_skin/bt_normal",
        "Parameters/C_hairs/bt_normal",
        "Parameters/C_hairs/Bt_cl",
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
        act_bts();
    }

    public void mouse_enter_viewport(){
        player_moving=true;
        player.SetProcessInput(true);
        player.SetPhysicsProcess(true);
        if(!globale.is_mobile()){
            Label l = (Label)GetNode("ViewPort/Inf_exit");
            l.Visible=true;
        }
    }
    public void mouse_exited_viewport(){
        if(!globale.is_mobile()){
            player_moving=false;
            player.stop_anim();
            player.set_anim_frame(0);
            player.SetProcessInput(false);
            player.SetPhysicsProcess(false);
            Label l = (Label)GetNode("ViewPort/Inf_exit");
            l.Visible=false;
        }
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
                    else if(bts_2.Contains(id_bt_act)){
                        TextureButton bt = (TextureButton)GetNode(bts_parameters[Array.IndexOf(bts_2, id_bt_act)][0]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                    else{
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
                    else if(bts_2.Contains(id_bt_act)){
                        TextureButton bt = (TextureButton)GetNode(bts_parameters[Array.IndexOf(bts_2, id_bt_act)][0]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                    else{
                        Button bt = (Button)GetNode(buttons[id_bt_act]);
                        bt.WarpMouse(bt.RectSize/2);
                        mouse_exited_viewport();
                    }
                }
            }
            if(Input.IsActionJustPressed("move_left")){
                if(bts_2.Contains(id_bt_act)){
                    TextureButton bt = (TextureButton)GetNode(bts_parameters[Array.IndexOf(bts_2, id_bt_act)][0]);
                    bt.EmitSignal("pressed");
                    bt.WarpMouse(bt.RectSize/2);
                }
            }if(Input.IsActionJustPressed("move_right")){
                if(bts_2.Contains(id_bt_act)){
                    TextureButton bt = (TextureButton)GetNode(bts_parameters[Array.IndexOf(bts_2, id_bt_act)][1]);
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

    public void on_cl_rect_pressed(){
        Control c_clpick = (Control)GetNode("Parameters/ColorPicker");
        c_clpick.Visible=true;
    }

    public void on_cl_pick_press(){
        Control c_clpick = (Control)GetNode("Parameters/ColorPicker");
        c_clpick.Visible=false;
    }

    public void on_cl_pick_change(Color cl){
        ColorRect clr = (ColorRect)GetNode("Parameters/C_hairs/Bt_cl/ColorRect");
        clr.Color=cl;
        globale.equipment.cl_hairs=cl;
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_gender_change(){
        globale.equipment.change_gender();
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_body_left(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.bodies_female.Keys.ToArray(),globale.equipment.player_body);
            idb--;
            if(idb<0){ idb=globale.equipment.bodies_female.Keys.Count-1; }
            globale.equipment.player_body=globale.equipment.bodies_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.bodies_male.Keys.ToArray(),globale.equipment.player_body);
            idb--;
            if(idb<0){ idb=globale.equipment.bodies_male.Keys.Count-1; }
            globale.equipment.player_body=globale.equipment.bodies_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_body_right(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.bodies_female.Keys.ToArray(),globale.equipment.player_body);
            idb++;
            if(idb>globale.equipment.bodies_female.Keys.Count-1){ idb=0; }
            globale.equipment.player_body=globale.equipment.bodies_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.bodies_male.Keys.ToArray(),globale.equipment.player_body);
            idb++;
            if(idb>globale.equipment.bodies_male.Keys.Count-1){ idb=0; }
            globale.equipment.player_body=globale.equipment.bodies_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_hair_left(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.hairs_female.Keys.ToArray(),globale.equipment.player_hair);
            idb--;
            if(idb<0){ idb=globale.equipment.hairs_female.Keys.Count-1; }
            globale.equipment.player_hair=globale.equipment.hairs_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.hairs_male.Keys.ToArray(),globale.equipment.player_hair);
            idb--;
            if(idb<0){ idb=globale.equipment.hairs_male.Keys.Count-1; }
            globale.equipment.player_hair=globale.equipment.hairs_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_hair_right(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.hairs_female.Keys.ToArray(),globale.equipment.player_hair);
            idb++;
            if(idb>globale.equipment.hairs_female.Keys.Count-1){ idb=0; }
            globale.equipment.player_hair=globale.equipment.hairs_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.hairs_male.Keys.ToArray(),globale.equipment.player_hair);
            idb++;
            if(idb>globale.equipment.hairs_male.Keys.Count-1){ idb=0; }
            globale.equipment.player_hair=globale.equipment.hairs_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_eyes_left(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.eyes_female.Keys.ToArray(),globale.equipment.player_eye);
            idb--;
            if(idb<0){ idb=globale.equipment.eyes_female.Keys.Count-1; }
            globale.equipment.player_eye=globale.equipment.eyes_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.eyes_male.Keys.ToArray(),globale.equipment.player_eye);
            idb--;
            if(idb<0){ idb=globale.equipment.eyes_male.Keys.Count-1; }
            globale.equipment.player_eye=globale.equipment.eyes_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void on_bt_eyes_right(){
        if(globale.equipment.is_player_female){
            int idb=Array.IndexOf(globale.equipment.eyes_female.Keys.ToArray(),globale.equipment.player_eye);
            idb++;
            if(idb>globale.equipment.eyes_female.Keys.Count-1){ idb=0; }
            globale.equipment.player_eye=globale.equipment.eyes_female.Keys.ToArray()[idb];
        }
        else{
            int idb=Array.IndexOf(globale.equipment.eyes_male.Keys.ToArray(),globale.equipment.player_eye);
            idb++;
            if(idb>globale.equipment.eyes_male.Keys.Count-1){ idb=0; }
            globale.equipment.player_eye=globale.equipment.eyes_male.Keys.ToArray()[idb];
        }
        act_bts();
        globale.equipment.act_player_equipement(player);
    }

    public void act_bts(){
        //Get labels
        Label l_gender=(Label)GetNode("Parameters/C_Gender/bt_normal/Label");
        Label l_body=(Label)GetNode("Parameters/C_skin/bt_normal/Label");
        Label l_hairs=(Label)GetNode("Parameters/C_hairs/bt_normal/Label");
        Label l_eyes = (Label)GetNode("Parameters/C_eyes/bt_normal/Label");
        ColorRect clr = (ColorRect)GetNode("Parameters/C_hairs/Bt_cl/ColorRect");
        ColorPicker clpick = (ColorPicker)GetNode("Parameters/ColorPicker/ColorPicker");
        Button btclr = (Button)GetNode("Parameters/C_hairs/Bt_cl");
        //Get values
        if(globale.equipment.is_player_female){ l_gender.Text="female"; }
        else{ l_gender.Text="male"; }
        l_body.Text=globale.equipment.player_body;
        l_hairs.Text=globale.equipment.player_hair;
        l_eyes.Text=globale.equipment.player_eye;
        clr.Color=globale.equipment.cl_hairs;
        clpick.Color=clr.Color;
        if(globale.equipment.is_player_female){ btclr.Disabled=!(globale.equipment.hairs_female_recolor[globale.equipment.player_hair]); }
        else{ btclr.Disabled=!(globale.equipment.hairs_male_recolor[globale.equipment.player_hair]); }
        
    }

    public void _on_Bt_next_pressed(){
        GetTree().ChangeScene("res://maps/Island_begining.tscn");
    }

}
