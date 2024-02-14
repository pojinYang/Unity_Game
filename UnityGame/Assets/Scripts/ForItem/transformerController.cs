using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class transformerController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    GameObject player;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.Find("Backpack");
        player = GameObject.Find("Player");
        Pos = transform.localPosition;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup&&fs.isCompleted){
                    setup = true;
                    fs.ReadTextFromResource("other 21");
                    player.transform.position = new Vector3(21.5f, -28.6f, 0);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("next2stair物體進入觸發器");
        Pos.y +=1.5f;
        hint.transform.localPosition = Pos;
        Pos.y -=1.5f;
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
