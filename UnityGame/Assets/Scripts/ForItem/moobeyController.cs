using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class moobeyController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
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
                    fs.ReadTextFromResource("moobey");
                    backpack.GetComponent<BackPackItem>().clue_grave = 1;
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
