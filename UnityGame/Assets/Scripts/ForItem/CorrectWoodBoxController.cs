using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class CorrectWoodBoxController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
    bool isFirst = true;
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
                    if(backpack.GetComponentInParent<BackPackItem>().invisible_lens == false && isFirst){
                        setup = true;
                        isFirst = false;
                        fs.ReadTextFromResource("correctbox");
                        backpack.GetComponentInParent<BackPackItem>().invisible_lens = true;
                    }else{
                        setup = true;
                        fs.ReadTextFromResource("wrongbox");
                    }
                    
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
        setup = false;
        isNear = false;
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
