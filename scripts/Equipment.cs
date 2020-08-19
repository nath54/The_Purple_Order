using System.Linq;
using System.Collections.Generic;
using Godot;
using System;

public class Equipment : Node
{

    // ############################# RESSOURCES : #############################
    //  BODIES
    public Dictionary<string, string> bodies_male=new Dictionary<string, string>(){
        {"white","res://player/spritesheets/body/male/man-white.tres"},
        {"black","res://player/spritesheets/body/male/man-black.tres"},
        {"brown","res://player/spritesheets/body/male/man-brown.tres"},
        {"olive","res://player/spritesheets/body/male/man-olive.tres"},
        {"peach","res://player/spritesheets/body/male/man-peach.tres"},
        {"dark","res://player/spritesheets/body/male/dark.tres"},
        {"dark2","res://player/spritesheets/body/male/dark2.tres"},
        {"tan","res://player/spritesheets/body/male/tanned2.tres"}
    };
    public Dictionary<string, string> bodies_female=new Dictionary<string, string>(){
        {"white","res://player/spritesheets/body/female/woman-white.tres"},
        {"black","res://player/spritesheets/body/female/woman-black.tres"},
        {"brown","res://player/spritesheets/body/female/woman-brown.tres"},
        {"olive","res://player/spritesheets/body/female/woman-olive.tres"},
        {"peach","res://player/spritesheets/body/female/woman-peach.tres"},
        {"dark","res://player/spritesheets/body/female/dark.tres"},
        {"dark2","res://player/spritesheets/body/female/dark2.tres"},
        {"tan","res://player/spritesheets/body/female/tanned2.tres"}
    };
    //  HAIRS
    public Dictionary<string, string> hairs_male=new Dictionary<string, string>(){
        {"bangs","res://player/spritesheets/hair/male/bangs.tres"},
        {"bangs long","res://player/spritesheets/hair/male/bangslong.tres"},
        {"bangs long 2","res://player/spritesheets/hair/male/bangslong2.tres"},
        {"bangs short","res://player/spritesheets/hair/male/bangsshort.tres"},
        {"bedhead","res://player/spritesheets/hair/male/bedhead.tres"},
        {"bunches","res://player/spritesheets/hair/male/bunches.tres"},
        {"jewfro","res://player/spritesheets/hair/male/jewfro.tres"},
        {"long","res://player/spritesheets/hair/male/long.tres"},
        {"longhawk","res://player/spritesheets/hair/male/longhawk.tres"},
        {"longknot","res://player/spritesheets/hair/male/longknot.tres"},
        {"loose","res://player/spritesheets/hair/male/loose.tres"},
        {"messy1","res://player/spritesheets/hair/male/messy1.tres"},
        {"messy2","res://player/spritesheets/hair/male/messy2.tres"},
        {"mohawk","res://player/spritesheets/hair/male/mohawk.tres"},
        {"page","res://player/spritesheets/hair/male/page.tres"},
        {"page2","res://player/spritesheets/hair/male/page2.tres"},
        {"parted","res://player/spritesheets/hair/male/parted.tres"},
        {"pixie","res://player/spritesheets/hair/male/pixie.tres"},
        {"plain","res://player/spritesheets/hair/male/plain.tres"},
        {"ponytail","res://player/spritesheets/hair/male/ponytail.tres"},
        {"ponytail2","res://player/spritesheets/hair/male/ponytail2.tres"},
        {"princess","res://player/spritesheets/hair/male/princess.tres"},
        {"shorthawk","res://player/spritesheets/hair/male/shorthawk.tres"},
        {"shortknot","res://player/spritesheets/hair/male/shortknot.tres"},
        {"shoulder-left","res://player/spritesheets/hair/male/shoulderl.tres"},
        {"shoulder-right","res://player/spritesheets/hair/male/shoulderr.tres"},
        {"swoop","res://player/spritesheets/hair/male/swoop.tres"},
        {"unkempt","res://player/spritesheets/hair/male/unkempt.tres"},
        {"xlong","res://player/spritesheets/hair/male/xlong.tres"},
        {"xlongknot","res://player/spritesheets/hair/male/xlongknot.tres"}
    };
    public Dictionary<string, bool> hairs_male_recolor=new Dictionary<string, bool>(){
        {"bangs",true},
        {"bangs long",true},
        {"bangs long 2",true},
        {"bangs short",true},
        {"bedhead",true},
        {"bunches",true},
        {"jewfro",true},
        {"long",true},
        {"longhawk",true},
        {"longknot",true},
        {"loose",true},
        {"messy1",true},
        {"messy2",true},
        {"mohawk",true},
        {"page",true},
        {"page2",true},
        {"parted",true},
        {"pixie",true},
        {"plain",true},
        {"ponytail",true},
        {"ponytail2",true},
        {"princess",true},
        {"shorthawk",true},
        {"shortknot",true},
        {"shoulder-left",true},
        {"shoulder-right",true},
        {"swoop",true},
        {"unkempt",true},
        {"xlong",true},
        {"xlongknot",true}
    };
    public Dictionary<string, string> hairs_female=new Dictionary<string, string>(){
        {"bangs","res://player/spritesheets/hair/female/bangs.tres"},
        {"bangs long","res://player/spritesheets/hair/female/bangslong.tres"},
        {"bangs long2","res://player/spritesheets/hair/female/bangslong2.tres"},
        {"bangs short","res://player/spritesheets/hair/female/bangsshort.tres"},
        {"bedhead","res://player/spritesheets/hair/female/bedhead.tres"},
        {"bunches","res://player/spritesheets/hair/female/bunches.tres"},
        {"jewfro","res://player/spritesheets/hair/female/jewfro.tres"},
        {"long","res://player/spritesheets/hair/female/long.tres"},
        {"LongHair black","res://player/spritesheets/hair/female/LongHair_black.tres"},
        {"LongHair brown","res://player/spritesheets/hair/female/LongHair_brunette.tres"},
        {"LongHair gold","res://player/spritesheets/hair/female/LongHair_gold.tres"},
        {"LongHair purple","res://player/spritesheets/hair/female/LongHair_purple.tres"},
        {"LongHair red","res://player/spritesheets/hair/female/LongHair_red.tres"},
        {"longhawk","res://player/spritesheets/hair/female/longhawk.tres"},
        {"longknot","res://player/spritesheets/hair/female/longknot.tres"},
        {"loose","res://player/spritesheets/hair/female/loose.tres"},
        {"messy1","res://player/spritesheets/hair/female/messy1.tres"},
        {"messy2","res://player/spritesheets/hair/female/messy2.tres"},
        {"mohawk","res://player/spritesheets/hair/female/mohawk.tres"},
        {"page","res://player/spritesheets/hair/female/page.tres"},
        {"page2","res://player/spritesheets/hair/female/page2.tres"},
        {"parted","res://player/spritesheets/hair/female/parted.tres"},
        {"pixie","res://player/spritesheets/hair/female/pixie.tres"},
        {"plain","res://player/spritesheets/hair/female/plain.tres"},
        {"ponytail","res://player/spritesheets/hair/female/ponytail.tres"},
        {"ponytail2","res://player/spritesheets/hair/female/ponytail2.tres"},
        {"princess","res://player/spritesheets/hair/female/princess.tres"},
        //{"SaraHairBottomLayer","res://player/spritesheets/hair/female/SaraHairBottomLayer.tres"},
        //{"SaraHairShadowOnFace","res://player/spritesheets/hair/female/SaraHairShadowOnFace.tres"},
        //{"SaraHairTopLayer","res://player/spritesheets/hair/female/SaraHairTopLayer.tres"},
        {"shorthawk","res://player/spritesheets/hair/female/shorthawk.tres"},
        {"shortknot","res://player/spritesheets/hair/female/shortknot.tres"},
        {"shoulderl","res://player/spritesheets/hair/female/shoulderl.tres"},
        {"shoulderr","res://player/spritesheets/hair/female/shoulderr.tres"},
        {"swoop","res://player/spritesheets/hair/female/swoop.tres"},
        {"unkempt","res://player/spritesheets/hair/female/unkempt.tres"},
        {"xlong","res://player/spritesheets/hair/female/xlong.tres"},
        {"xlongknot","res://player/spritesheets/hair/female/xlongknot.tres"},
    };
    public Dictionary<string, bool> hairs_female_recolor=new Dictionary<string, bool>(){
        {"bangs",true},
        {"bangs long",true},
        {"bangs long2",true},
        {"bangs short",true},
        {"bedhead",true},
        {"bunches",true},
        {"jewfro",true},
        {"long",true},
        {"LongHair black",false},
        {"LongHair brown",false},
        {"LongHair gold",false},
        {"LongHair purple",false},
        {"LongHair red",false},    
        {"longhawk",true},
        {"longknot",true},
        {"loose",true},
        {"messy1",true},
        {"messy2",true},
        {"mohawk",true},
        {"page",true},
        {"page2",true},
        {"parted",true},
        {"pixie",true},
        {"plain",true},
        {"ponytail",true},
        {"ponytail2",true},
        {"princess",true},
        {"SaraHairBottomLayer",true},
        {"SaraHairShadowOnFace",true},
        {"SaraHairTopLayer",true},
        {"shorthawk",true},
        {"shortknot",true},
        {"shoulderl",true},
        {"shoulderr",true},
        {"swoop",true},
        {"unkempt",true},
        {"xlong",true},
        {"xlongknot",true},
    };
    //EYES
    public Dictionary<string, string> eyes_male = new Dictionary<string, string>(){
        {"blue","res://player/spritesheets/body/male/eyes/blue.tres"},
        {"brown","res://player/spritesheets/body/male/eyes/brown.tres"},
        {"gray","res://player/spritesheets/body/male/eyes/gray.tres"},
        {"orange","res://player/spritesheets/body/male/eyes/orange.tres"},
        {"purple","res://player/spritesheets/body/male/eyes/purple.tres"},
        {"red","res://player/spritesheets/body/male/eyes/red.tres"},
        {"yellow","res://player/spritesheets/body/male/eyes/yellow.tres"},
    };
    public Dictionary<string, string> eyes_female = new Dictionary<string, string>(){
        {"blue","res://player/spritesheets/body/female/eyes/blue.tres"},
        {"brown","res://player/spritesheets/body/female/eyes/brown.tres"},
        {"gray","res://player/spritesheets/body/female/eyes/gray.tres"},
        {"orange","res://player/spritesheets/body/female/eyes/orange.tres"},
        {"purple","res://player/spritesheets/body/female/eyes/purple.tres"},
        {"red","res://player/spritesheets/body/female/eyes/red.tres"},
        {"yellow","res://player/spritesheets/body/female/eyes/yellow.tres"},
    };
    //Behind Body
    public Dictionary<string, string> behind_body_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> behind_body_female = new Dictionary<string, string>(){};
    //Accessories
    public Dictionary<string, string> accessories_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> accessories_female = new Dictionary<string, string>(){};
    //Belt
    public Dictionary<string, string> belt_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> belt_female = new Dictionary<string, string>(){};
    //Arms
    public Dictionary<string, string> arms_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> arms_female = new Dictionary<string, string>(){};
    //Hands
    public Dictionary<string, string> hands_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> hands_female = new Dictionary<string, string>(){};
    //Legs
    public Dictionary<string, string> legs_male = new Dictionary<string, string>(){
        {"teal-pants","res://player/spritesheets/legs/pants/male/teal_pants_male.tres"},
    };
    public Dictionary<string, string> legs_female = new Dictionary<string, string>(){
        {"teal-pants","res://player/spritesheets/legs/pants/female/teal_pants_female.tres"}
    };
    //feet
    public Dictionary<string, string> feet_male = new Dictionary<string, string>(){
        {"brown-shoes","res://player/spritesheets/feet/shoes/male/brown_shoes_male.tres"},
    };
    public Dictionary<string, string> feet_female = new Dictionary<string, string>(){
        {"brown-shoes","res://player/spritesheets/feet/shoes/female/brown_shoes_female.tres"},
    };
    //Torsos
    public Dictionary<string, string> torsos_male = new Dictionary<string, string>(){
        {"leather-chest","res://player/spritesheets/torso/leather/chest_male.tres"},
    };
    public Dictionary<string, string> torsos_female = new Dictionary<string, string>(){
        {"leather-chest","res://player/spritesheets/torso/leather/chest_female.tres"},
    };
    //Shoulders
    public Dictionary<string, string> shoulders_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> shoulders_female = new Dictionary<string, string>(){};
    //Heads
    public Dictionary<string, string> heads_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> heads_female = new Dictionary<string, string>(){};
    //Facials
    public Dictionary<string, string> facials_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> facials_female = new Dictionary<string, string>(){};
    //Weapons
    public Dictionary<string, string> weapons_male = new Dictionary<string, string>(){};
    public Dictionary<string, string> weapons_female = new Dictionary<string, string>(){};
    
    



    // ############################# VALEURS : #############################

    public bool is_player_female=false;
    public string player_body="white";
    public string player_hair="bangs";
    public string player_eye="blue";
    public string player_behind_body=null;
    public string player_belt=null;
    public string player_arm=null;
    public string player_hand=null;
    public string player_leg="teal-pants";
    public string player_feet="brown-shoes";
    public string player_torso="leather-chest";
    public string player_shoulder=null;
    public string player_head=null;
    public string player_facial=null;
    public string player_accessory=null;
    public string player_weapon=null;
    public Godot.Color cl_hairs = new Godot.Color(0.42F,0.26F,0.15F);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void change_gender(){
        if(is_player_female){
            is_player_female=false;
            //test hairs
            if(!(hairs_male.Keys.Contains(player_hair))){
                player_hair=hairs_male.Keys.ToArray()[0];
            }
            //test eyes
            if(!(eyes_male.Keys.Contains(player_eye))){
                player_eye=eyes_male.Keys.ToArray()[0];
            }
        }
        else{
            is_player_female=true;
            //test hairs
            if(!(hairs_female.Keys.Contains(player_hair))){
                player_hair=hairs_female.Keys.ToArray()[0];
            }
            //test eyes
            if(!(eyes_female.Keys.Contains(player_eye))){
                player_eye=eyes_female.Keys.ToArray()[0];
            }
        }
    }

    public void act_player_equipement(Player p){
        //BODY
        AnimatedSprite an_body = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["body"]);
        if(an_body!=null){
            SpriteFrames sf_body=ResourceLoader.Load(bodies_male[player_body]) as SpriteFrames;
            if(is_player_female){ sf_body=ResourceLoader.Load(bodies_female[player_body]) as SpriteFrames; }
            an_body.Frames=sf_body;
        }
        //HAIR
        AnimatedSprite an_hair = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["hair"]);
        if(an_hair!=null){
            SpriteFrames sf_hair=null;
            if(!is_player_female && hairs_male[player_hair]!=null){
                sf_hair=ResourceLoader.Load(hairs_male[player_hair]) as SpriteFrames;
            }                        
            if(is_player_female && hairs_female[player_hair]!=null){
                sf_hair=ResourceLoader.Load(hairs_female[player_hair]) as SpriteFrames;
            }
            an_hair.Frames=sf_hair;
            if(is_player_female){
                if( hairs_female_recolor[player_hair] ){
                    an_hair.Modulate=cl_hairs;
                }
                else{
                    an_hair.Modulate=new Color(1,1,1);
                }
            }
            else{
                if( hairs_male_recolor[player_hair] ){
                    an_hair.Modulate=cl_hairs;
                }
                else{
                    an_hair.Modulate=new Color(1,1,1);
                }
            }
        }
        //EYES
        AnimatedSprite an_eye = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["eye"]);
        if(an_eye!=null){
            SpriteFrames sf_eye=null;
            if(!is_player_female && eyes_male[player_eye]!=null){
                sf_eye=ResourceLoader.Load(eyes_male[player_eye]) as SpriteFrames;
            }                        
            if(is_player_female && eyes_female[player_eye]!=null){
                sf_eye=ResourceLoader.Load(eyes_female[player_eye]) as SpriteFrames;
            }
            an_eye.Frames=sf_eye;
        }
        //BEHIND BODY
        AnimatedSprite an_bb = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["behind_body"]);
        if(an_bb!=null){
            SpriteFrames sf_bb=null;
            if(player_behind_body!=null){
                if(!is_player_female && eyes_male[player_behind_body]!=null){
                sf_bb=ResourceLoader.Load(eyes_male[player_behind_body]) as SpriteFrames;
                }                        
                if(is_player_female && eyes_female[player_behind_body]!=null){
                    sf_bb=ResourceLoader.Load(eyes_female[player_behind_body]) as SpriteFrames;
                }
            }
            an_bb.Frames=sf_bb;
        }
        //BELT
        AnimatedSprite an_belt = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["belt"]);
        if(an_belt!=null){
            SpriteFrames sf_belt=null;
            if(player_belt!=null){
                if(!is_player_female && belt_male[player_belt]!=null){
                sf_belt=ResourceLoader.Load(belt_male[player_belt]) as SpriteFrames;
                }                        
                if(is_player_female && belt_female[player_belt]!=null){
                    sf_belt=ResourceLoader.Load(belt_female[player_belt]) as SpriteFrames;
                }
            }
            an_belt.Frames=sf_belt;
        }
        //ARM
        AnimatedSprite an_arm = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["arm"]);
        if(an_arm!=null){
            SpriteFrames sf_arm=null;
            if(player_arm!=null){
                if(!is_player_female && arms_male[player_arm]!=null){
                sf_arm=ResourceLoader.Load(arms_male[player_arm]) as SpriteFrames;
                }                        
                if(is_player_female && arms_female[player_arm]!=null){
                    sf_arm=ResourceLoader.Load(arms_female[player_arm]) as SpriteFrames;
                }
            }
            an_arm.Frames=sf_arm;
        }
        //HAND
        AnimatedSprite an_hand = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["hand"]);
        if(an_hand!=null){
            SpriteFrames sf_hand=null;
            if(player_hand!=null){
                if(!is_player_female && hands_male[player_hand]!=null){
                sf_hand=ResourceLoader.Load(hands_male[player_hand]) as SpriteFrames;
                }                        
                if(is_player_female && hands_female[player_hand]!=null){
                    sf_hand=ResourceLoader.Load(hands_female[player_hand]) as SpriteFrames;
                }
            }
            an_hand.Frames=sf_hand;
        }
        //LEG
        AnimatedSprite an_leg = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["leg"]);
        if(an_leg!=null){
            SpriteFrames sf_leg=null;
            if(player_leg!=null){
                if(!is_player_female && legs_male[player_leg]!=null){
                sf_leg=ResourceLoader.Load(legs_male[player_leg]) as SpriteFrames;
                }                        
                if(is_player_female && legs_female[player_leg]!=null){
                    sf_leg=ResourceLoader.Load(legs_female[player_leg]) as SpriteFrames;
                }
            }
            an_leg.Frames=sf_leg;
        }
        //FEET
        AnimatedSprite an_feet = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["feet"]);
        if(an_feet!=null){
            SpriteFrames sf_feet=null;
            if(player_feet!=null){
                if(!is_player_female && feet_male[player_feet]!=null){
                sf_feet=ResourceLoader.Load(feet_male[player_feet]) as SpriteFrames;
                }                        
                if(is_player_female && feet_female[player_feet]!=null){
                    sf_feet=ResourceLoader.Load(feet_female[player_feet]) as SpriteFrames;
                }
            }
            an_feet.Frames=sf_feet;
        }
        //TORSO
        AnimatedSprite an_torso = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["torso"]);
        if(an_torso!=null){
            SpriteFrames sf_torso=null;
            if(player_torso!=null){
                if(!is_player_female && torsos_male[player_torso]!=null){
                sf_torso=ResourceLoader.Load(torsos_male[player_torso]) as SpriteFrames;
                }                        
                if(is_player_female && torsos_female[player_torso]!=null){
                    sf_torso=ResourceLoader.Load(torsos_female[player_torso]) as SpriteFrames;
                }
            }
            an_torso.Frames=sf_torso;
        }
        //SHOULDERS
        AnimatedSprite an_shoulder = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["shoulder"]);
        if(an_shoulder!=null){
            SpriteFrames sf_shoulder=null;
            if(player_shoulder!=null){
                if(!is_player_female && shoulders_male[player_shoulder]!=null){
                sf_shoulder=ResourceLoader.Load(shoulders_male[player_shoulder]) as SpriteFrames;
                }                        
                if(is_player_female && shoulders_female[player_shoulder]!=null){
                    sf_shoulder=ResourceLoader.Load(shoulders_female[player_shoulder]) as SpriteFrames;
                }
            }
            an_shoulder.Frames=sf_shoulder;
        }
        //HEAD
        AnimatedSprite an_head = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["head"]);
        if(an_head!=null){
            SpriteFrames sf_head=null;
            if(player_head!=null){
                if(!is_player_female && heads_male[player_head]!=null){
                sf_head=ResourceLoader.Load(heads_male[player_head]) as SpriteFrames;
                }                        
                if(is_player_female && heads_female[player_head]!=null){
                    sf_head=ResourceLoader.Load(heads_female[player_head]) as SpriteFrames;
                }
            }
            an_head.Frames=sf_head;
        }
        //FACIAL
        AnimatedSprite an_facial = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["facial"]);
        if(an_facial!=null){
            SpriteFrames sf_facial=null;
            if(player_facial!=null){
                if(!is_player_female && facials_male[player_facial]!=null){
                sf_facial=ResourceLoader.Load(facials_male[player_facial]) as SpriteFrames;
                }                        
                if(is_player_female && facials_female[player_facial]!=null){
                    sf_facial=ResourceLoader.Load(facials_female[player_facial]) as SpriteFrames;
                }
            }
            an_facial.Frames=sf_facial;
        }
        //ACCESSORY
        AnimatedSprite an_accessory = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["accessory"]);
        if(an_accessory!=null){
            SpriteFrames sf_accessory=null;
            if(player_accessory!=null){
                if(!is_player_female && accessories_male[player_accessory]!=null){
                sf_accessory=ResourceLoader.Load(accessories_male[player_accessory]) as SpriteFrames;
                }                        
                if(is_player_female && accessories_female[player_accessory]!=null){
                    sf_accessory=ResourceLoader.Load(accessories_female[player_accessory]) as SpriteFrames;
                }
            }
            an_accessory.Frames=sf_accessory;
        }
        //WEAPON
        AnimatedSprite an_weapon = (AnimatedSprite)GetNode(p.GetPath()+"/"+p.equipment_act["weapon"]);
        if(an_weapon!=null){
            SpriteFrames sf_weapon=null;
            if(player_weapon!=null){
                if(!is_player_female && weapons_male[player_weapon]!=null){
                sf_weapon=ResourceLoader.Load(weapons_male[player_weapon]) as SpriteFrames;
                }                        
                if(is_player_female && weapons_female[player_weapon]!=null){
                    sf_weapon=ResourceLoader.Load(weapons_female[player_weapon]) as SpriteFrames;
                }
            }
            an_weapon.Frames=sf_weapon;
        }

        

    }

}
