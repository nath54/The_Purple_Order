using System.Collections.Generic;
using Godot;
using System;

public class Langues : Node
{
    
    public string langactu="";

    public Dictionary<string, string> textes = new Dictionary<string, string>(){

    };

    public void parcour_node(Node node){
        //
        if(node is Button nb){
            string path = nb.GetPath();
            if( textes.ContainsKey(path) ){
                nb.Text=textes[path];
            }
        }
        //
        if(node is Label nl){
            string path = nl.GetPath();
            if( textes.ContainsKey(path) ){
                nl.Text=textes[path];
            }
        }
        //
        //
    }

    public void act_textes(){
        foreach(Node n in GetTree().Root.GetChildren()){
            parcour_node(n);
        }
    }

    public void chang_lang(string newlang){
        if(newlang=="fr"){
            fr l = new fr();
            textes = l.textes;
            act_textes();
        }
        else{
            en l = new en();
            textes = l.textes;
            act_textes();
        }
    }


    public override void _Ready(){
        langactu="fr";
        chang_lang(langactu);
        act_textes();
    }

}
