using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class achi_test_Controller : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    public GameObject hint;
    public bool isAchi;
    
    Vector3 Pos = new Vector3(0, 0, 0);
    void Start()
    {   
        Pos = transform.localPosition;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        
    }

    void ResetAchi(){
        isAchi = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(isNear){
            

            

            
            
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    fs.ReadTextFromResource("other 37");
                    setup = true;
                }else{

                    fs.Next();

                }
                                    
                                

            }
                
        }
            
        if(isAchi) this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        else this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            
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
