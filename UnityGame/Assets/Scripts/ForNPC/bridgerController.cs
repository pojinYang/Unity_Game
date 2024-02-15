using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class bridgerController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    bool run = false;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    void Start()
    {   
        backpack = GameObject.Find("Backpack");
        
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        transform.localPosition = new Vector3(-50,-14,0);
        Pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(run){
            Pos = transform.localPosition;
            if(Pos.x<-44) transform.Translate(0.03f, 0, 0);
            else if (Pos.y>-200) transform.Translate(0, -0.03f, 0);
        } 


        if(isNear){
            

            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    if(backpack.GetComponent<BackPackItem>().stage==9){
                        run = true;
                        fs.ReadTextFromResource("stage 11");
                        backpack.GetComponent<BackPackItem>().stone_plate = true;
                        
                    }
                    else{
                        fs.ReadTextFromResource("stage 10");
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
