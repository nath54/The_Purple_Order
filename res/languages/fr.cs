using System.Collections.Generic;
using Godot;
using System;

public class fr : Node
{
    
    public Dictionary<string, string> textes= new Dictionary<string, string>(){
        {"Buttons/VBoxContainer/Bt_continue", "Continuer"},
        {"Buttons/VBoxContainer/Bt_newgame", "Nouvelle Partie"},
        {"Buttons/VBoxContainer/Bt_load", "Charger"},
        {"Buttons/VBoxContainer/Bt_settings", "Configuration"},
        {"Buttons/VBoxContainer/Bt_quit", "Quitter"},
    };

}
