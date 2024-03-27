using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class Exploser : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool isEnd=false;
    void Start()
    {   
        backpack = GameObject.Find("Backpack");
        Pos = transform.localPosition;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isNear){
            
            if(fs.isCompleted&&isEnd==false&&setup){
                Debug.Log("isCompleted"); 
                
                fs.SetupButtonGroup();
                
                // 什麼都不燒 
                fs.SetupButton("......",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 13");
                });

                // 火焰花->祭祀之火
                if(backpack.GetComponent<BackPackItem>().fire_flower){
                    fs.SetupButton("火焰花",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 14");
                    backpack.GetComponent<BackPackItem>().fire_flower = false;
                    backpack.GetComponent<BackPackItem>().fire = true;
                    });
                }
                
                // 植物精華->火焰精華
                if(backpack.GetComponent<BackPackItem>().plant_ginhua){
                    fs.SetupButton("植物精華",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 15");
                    backpack.GetComponent<BackPackItem>().plant_ginhua = false;
                    backpack.GetComponent<BackPackItem>().fire_ginhua = true;
                    
                    });
                }

                // 什覓草->灰燼
                if(backpack.GetComponent<BackPackItem>().herb){
                    fs.SetupButton("什覓草",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 16");
                    backpack.GetComponent<BackPackItem>().herb = false;
                    backpack.GetComponent<BackPackItem>().ash = true;
                    
                    });
                }

                // 聖劍->火箭
                if(backpack.GetComponent<BackPackItem>().sword){
                    fs.SetupButton("聖騎士之劍",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 17");
                    backpack.GetComponent<BackPackItem>().sword = false;
                    backpack.GetComponent<BackPackItem>().rocket = true;
                    
                    });
                }

                // 石板->X
                if(backpack.GetComponent<BackPackItem>().slate){
                    fs.SetupButton("石板",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other"); // 請提醒我要做這裡
                    });
                }

                // 隱形眼鏡->玻璃渣渣
                if(backpack.GetComponent<BackPackItem>().invisible_lens){
                    fs.SetupButton("隱形眼鏡",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other"); // 請提醒我要做這裡
                    backpack.GetComponent<BackPackItem>().invisible_lens = false;
                    backpack.GetComponent<BackPackItem>().glass_chip = true;
                    
                    });
                }

                // 放大鏡->火焰放大器
                if(backpack.GetComponent<BackPackItem>().magnifier){
                    fs.SetupButton("放大鏡",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other"); // 請提醒我要做這裡
                    backpack.GetComponent<BackPackItem>().magnifier = false;
                    backpack.GetComponent<BackPackItem>().fire_up = true;
                    
                    });
                }

                isEnd = true;
            }



            
            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    fs.ReadTextFromResource("stage 15");
                    
                    
                        
                    
                    /*fs.SetupButton("buttom name",()=>{
                                            
                    });*/

                    setup = true;
                    
                }else{

                    fs.Next();

                    
                }
                                    
                                

            }
                
        }
        

            
    }
    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("next2stair物體進入觸發器");
        Pos.y +=0.9f;
        hint.transform.localPosition = Pos;
        Pos.y -=0.9f;
        hint.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isNear = true;
        isEnd = false;
    }

    void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("next2stair物體離開觸發器");
        

        isNear = false;
        setup = false;
        
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
