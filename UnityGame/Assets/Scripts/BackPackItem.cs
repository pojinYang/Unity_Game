using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool invisible_lens = false; //隱形眼鏡  //燒不了
    public bool herb = false;  //藥材  
    public bool stone_plate = false;  //石板
    public bool fire_flower = false;  //火焰花
    public bool plant_ginhua = false;  //植物精華
    public bool fire = false;  //祭祀之火
    public bool treasure = false;  //祕寶
    public bool sword = false; //聖劍 
    public bool sword_key = false;   //燒不了
    public bool treasure_key = false;    //燒不了
    public bool ash = false;
    public bool fire_ginhua = false;  //火焰精華
    public bool rocket = false; //火箭

    // 線索紀錄
    public int clue_herb = 0;
    public int clue_stone_plate = 0;
    public int clue_fire = 0;
    public int clue_grave = 0;
    public int clue = 0;

    public int stage;
    public int stage2;
    public int Ghost_Game1=0;
    /* 0:未開始
       1:進行中
       2:結束
    */
    GameObject fist;
    GameObject player;
    void Start()
    {
        fist=GameObject.Find("Ghost_Game");
        player=GameObject.Find("Player");
        stage = 1;
        stage2 = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        clue = clue_herb + clue_stone_plate + clue_fire + clue_grave;
        if(stage==6&&Ghost_Game1==0){
            player.transform.position = new Vector3(-191.7f, -10.7f, 0);
            Ghost_Game1=1;
            fist.GetComponent<fistGenerator>().isHit=false;
            fist.GetComponent<fistGenerator>().times=0;
            player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(Ghost_Game1==1&&stage==6){
            fist.GetComponent<fistGenerator>().Playing();
        }
        else if(Ghost_Game1==2){
            if(fist.GetComponent<fistGenerator>().isHit)
                stage=5;
            else
                stage=7;
            player.transform.position = new Vector3(-22.9f, -5.8f, 0);
            player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Ghost_Game1=0;
        }
    }
}
