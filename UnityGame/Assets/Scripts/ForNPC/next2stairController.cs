using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class next2stairController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    GameObject hint;
    Vector3 Pos = new Vector3(0, 0, 0);
    void Start()
    {   
        Pos = transform.localPosition;
        Pos.x-=1.59f;
        Pos.y-=0.7f;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isNear){
            

            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    fs.ReadTextFromResource("next2stair_talk");
                    setup = true;
                }else{

                    fs.Next();

                }
                                    
                                

            }
                
        }
            

            
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("next2stair物體進入觸發器");
        
        hint.transform.localPosition = Pos;
        hint.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isNear = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("next2stair物體離開觸發器");
        

        isNear = false;
        setup = false;
        
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
