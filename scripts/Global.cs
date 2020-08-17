using System.Collections.Generic;
using Godot;
using System;

public class Global : Node
{
    public Langues langues;
    public string langactu="fr";
    public List<string> saves= new List<string>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        langues=(Langues)GetNode("/root/Langues");
    }

    public void act_lang(){
        if(langues.langactu!=langactu){
            langues.chang_lang(langactu);
        }
        langues.act_textes();
    }


}
