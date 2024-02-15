using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class HerbController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
    bool haveherb = true;
    // Start is called before the first frame update
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
                    setup = true;

                    if(backpack.GetComponent<BackPackItem>().stage<8){
                        fs.ReadTextFromResource("herb_talk_2");
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==8){
                        if(haveherb){
                            fs.ReadTextFromResource("stage 8");
                            backpack.GetComponentInParent<BackPackItem>().herb = true;
                            haveherb = false;
                        }else{
                            fs.ReadTextFromResource("herb_talk_3");
                        }
                        
                    }
                    if(backpack.GetComponent<BackPackItem>().stage>8){
                        fs.ReadTextFromResource("herb_talk_3");
                    }
                    
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("herb物體進入觸發器");
        Pos.y +=0.9f;
        hint.transform.localPosition = Pos;
        Pos.y -=0.9f;
        hint.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isNear = true;

    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("herb物體離開觸發器");
        setup = false;
        isNear = false;
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
