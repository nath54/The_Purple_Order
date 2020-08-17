using System.Collections.Generic;
using Godot;
using System;

public class en : Node
{
    public Dictionary<string, string> textes= new Dictionary<string, string>(){
        {"Buttons/VBoxContainer/Bt_continue", "Continue"},
        {"Buttons/VBoxContainer/Bt_newgame", "New Game"},
        {"Buttons/VBoxContainer/Bt_load", "load"},
        {"Buttons/VBoxContainer/Bt_settings", "settings"},
        {"Buttons/VBoxContainer/Bt_quit", "quit"},
    };

}
