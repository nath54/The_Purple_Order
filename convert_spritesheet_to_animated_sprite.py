#coding:utf-8
import os,io

deb_chem="imgs/spritesheets/"
deb_nchems="player/spritesheets/"

def test_dir(chem,deb_nchems):
    for o in os.listdir(chem):
        if len(o.split("."))==1:
            test_dir(chem+o+"/",deb_nchems+o+"/")
        elif o.endswith("png"):
            create_sprite(chem+o,deb_nchems+o.split(".")[0]+".tres")


def create_sprite(chem,nchem):
    tc="./"
    for c in nchem.split("/")[:-1]:
        if not c in os.listdir(tc):
            os.mkdir(tc+c)
        tc+=c+"/"
    
    af=io.open("player/Blank.tres","r",encoding="utf-8")
    atxt=af.read()
    af.close()

    ntxt=atxt.replace("res://imgs/perso/Male/Bodies/White.png","res://"+chem)
    nf=io.open(nchem,"w",encoding="utf-8")
    nf.write(ntxt)
    nf.close()

test_dir(deb_chem,deb_nchems)
