using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class pharmacistController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    bool isEnd = false;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
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
                fs.SetupButtonGroup();

                // 啥都不做
                fs.SetupButton("......",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 9");
                });

                // 獲取植物精華
                if(backpack.GetComponent<BackPackItem>().stage2==1 && backpack.GetComponent<BackPackItem>().plant_ginhua==false){
                    fs.SetupButton("關於火焰花...",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 10");
                    backpack.GetComponent<BackPackItem>().plant_ginhua = true;
                    });
                }

                // 獲取線索
                if(backpack.GetComponent<BackPackItem>().stage==8 && backpack.GetComponent<BackPackItem>().plant_ginhua==false){
                    fs.SetupButton("關於什覓草...",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 11");
                    backpack.GetComponent<BackPackItem>().clue_herb = 1;
                    });
                }

                isEnd = true;
            }
            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    fs.ReadTextFromResource("stage 16");
                    
                    
                    
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
