using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class nonameController : MonoBehaviour
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
                    
                    if(backpack.GetComponent<BackPackItem>().stage==1)
                        fs.ReadTextFromResource("other 19");
                    if(backpack.GetComponent<BackPackItem>().stage==2)
                        fs.ReadTextFromResource("stage 2");
                    if(backpack.GetComponent<BackPackItem>().stage==3){
                        if(backpack.GetComponent<BackPackItem>().invisible_lens == true){
                            fs.ReadTextFromResource("stage 3");
                            backpack.GetComponent<BackPackItem>().invisible_lens = false;
                        }else{
                            fs.ReadTextFromResource("other 2");
                        }
                    }
                    if(backpack.GetComponent<BackPackItem>().stage>3)
                        fs.ReadTextFromResource("other 3");
                    
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
