using System.Collections.Generic;
using Godot;
using System;

public class en : Node
{
    public Dictionary<string, string> textes= new Dictionary<string, string>(){
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_continue", "Continue"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_newgame", "New Game"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_load", "load"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_settings", "settings"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_quit", "quit"},
    };

}
