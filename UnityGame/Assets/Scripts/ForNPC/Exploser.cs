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
    bool isLock = false;
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
            
            if(fs.isCompleted&&isEnd==false&&setup&&!isLock){
                Debug.Log("isCompleted"); 
                fs.SetupButtonGroup();
                if(backpack.GetComponent<BackPackItem>().fire_flower){
                    fs.SetupButton("火焰花",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other0");
                    backpack.GetComponent<BackPackItem>().fire_flower = false;
                    backpack.GetComponent<BackPackItem>().fire = true;
                    isLock = false;
                    });
                }
                isLock = true;
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
    }

    void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("next2stair物體離開觸發器");
        

        isNear = false;
        setup = false;
        
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
