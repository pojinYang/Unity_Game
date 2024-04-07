using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class knightController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    public bool setup = false;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    void Start()
    {   
        backpack = GameObject.Find("Backpack");
        Pos = transform.localPosition;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        transform.localPosition = new Vector3(-4.47f,-30.4f,0);
    }

    // Update is called once per frame
    void Update()
    {   if(backpack.GetComponent<BackPackItem>().stage3==2&&fs.isCompleted) {
            fs.ReadTextFromResource("stage 21_1");
            backpack.GetComponent<BackPackItem>().stage3=3;
        }
        
        if(isNear){
            

           

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    if(backpack.GetComponent<BackPackItem>().stage3 == 1){
                        fs.ReadTextFromResource("GoGoGO");
                        backpack.GetComponent<BackPackItem>().stage3 = 100;
                        GameObject.Find("Player").transform.position = new Vector3(0f,36f,0);
                    
                    }
                    else if(backpack.GetComponent<BackPackItem>().sword == true&&backpack.GetComponent<BackPackItem>().stage3==0) 
                    {fs.ReadTextFromResource("stage 21"); 
                     //BOSS戰
                        backpack.GetComponent<BackPackItem>().sword = false;
                        backpack.GetComponent<BackPackItem>().stage3 = 1;
                    }
                    
                    else if(backpack.GetComponent<BackPackItem>().clue_steal != 1 || backpack.GetComponent<BackPackItem>().clue < 3) fs.ReadTextFromResource("other 20");
                    else if(backpack.GetComponent<BackPackItem>().clue_steal == 1 && backpack.GetComponent<BackPackItem>().clue == 3){
                        fs.ReadTextFromResource("stage 20");
                        backpack.GetComponent<BackPackItem>().sword_key = true;
                    }


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
    public void escape(){
        isNear = false;
        setup = false;
        
        hint.transform.localScale = new Vector3(0, 0, 0);

    }
}
