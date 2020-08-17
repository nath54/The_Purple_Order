using System.Collections.Generic;
using Godot;
using System;

public class fr : Node
{
    
    public Dictionary<string, string> textes= new Dictionary<string, string>(){
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_continue", "Continuer"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_newgame", "Nouvelle Partie"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_load", "Charger"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_settings", "Configuration"},
        {"/root/MainMenu/Buttons/VBoxContainer/Bt_quit", "Quitter"},
    };

}
