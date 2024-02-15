using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class BackPackItem : MonoBehaviour
{
    FlowerSystem fs;
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
    public bool magnifier = false; //放大鏡

    // 線索紀錄
    public int clue_herb = 0;
    public int clue_stone_plate = 0;
    public int clue_fire = 0;
    public int clue_grave = 0;
    public int clue_steal = 0;
    public int clue = 0;

    public int stage = 0;
    public int stage2 = 0;
    public int stage3 = 0;
    public int Ghost_Game1=0;

    public bool isGhostGameFinished = false;
    /* 0:未開始
       1:進行中
       2:結束
    */
    GameObject fist;
    GameObject player;

    GameObject witch_hit;
    GameObject knight_hit;
    GameObject Boss_Game;
    void Start()
    {   
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        fist=GameObject.Find("Ghost_Game");
        Boss_Game=GameObject.Find("Boss_Game");
        player=GameObject.Find("Player");
        stage = 0;
        stage2 = 0;
        stage3 = 0;
        witch_hit = GameObject.Find("Boss_Game").transform.GetChild(1).gameObject;
        knight_hit = GameObject.Find("Boss_Game").transform.GetChild(0).gameObject;
        witch_hit.transform.localScale = new Vector3(0, 0, 0);
        knight_hit.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        
        clue = clue_herb + clue_stone_plate + clue_fire + clue_grave;
        if(!isGhostGameFinished){
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
                if(fist.GetComponent<fistGenerator>().isHit){
                    stage=4;
                    player.transform.position = new Vector3(-22.9f, -5.8f, 0);
                    player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Ghost_Game1=0;
                }
                    
                else{
                    stage=7;
                    isGhostGameFinished = true;
                    player.transform.position = new Vector3(-22.9f, -5.8f, 0);
                    player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Ghost_Game1=0;
                    fs.ReadTextFromResource("stage 7");
                    stage = 8;
                }
                    
                
                
                
            }


        }else{
            //boss 關卡
            if(stage3==1&&Ghost_Game1==0&&fs.isCompleted){
                player.transform.position = new Vector3(-191.7f, -10.7f, 0);
                Ghost_Game1=1;
                Boss_Game.GetComponent<fistGenerator_Boss>().isHit=false;
                Boss_Game.GetComponent<fistGenerator_Boss>().times=0;
                player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = true;
                stage3=2;
                witch_hit.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                knight_hit.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                GameObject.Find("knight").transform.localScale = new Vector3(0,0,0);
                GameObject.Find("knight").transform.position = new Vector3(500, 500, 0);
                GameObject.Find("hint").transform.localScale = new Vector3(0, 0, 0);
                
            }
            else if(Ghost_Game1==1&&fs.isCompleted&&stage3==3){
                Boss_Game.GetComponent<fistGenerator_Boss>().Playing();
            }
            else if(Ghost_Game1==2){
                
                    
                    
                    stage3=4;
                    fs.ReadTextFromResource("stage 22");
                    Ghost_Game1=0;
                    

                
                    
            }
            if(fs.isCompleted&&stage3==4){
                player.transform.position = new Vector3(-4.47f,-30.4f,0);
                player.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                fs.ReadTextFromResource("stage 23");
                treasure_key = true;
                stage3=5;
            }
        }

    }










}
        
        
        

