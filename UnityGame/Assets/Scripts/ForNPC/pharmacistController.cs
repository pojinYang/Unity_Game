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
            

            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    if(backpack.GetComponent<BackPackItem>().stage2==2 && backpack.GetComponent<BackPackItem>().plant_ginhua==false){
                        fs.ReadTextFromResource("stage 16");
                        backpack.GetComponent<BackPackItem>().plant_ginhua = true;
                        backpack.GetComponent<BackPackItem>().stage2=3;
                    }else{
                        fs.ReadTextFromResource("other");
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
}
