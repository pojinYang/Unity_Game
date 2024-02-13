using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class box_of_treasure : MonoBehaviour
{
    public bool isNear = false;
    public bool isOpen = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
    // Start is called before the first frame update
    public Sprite box_open;

    void Start()
    {
        backpack = GameObject.Find("Backpack");
        Pos = transform.localPosition;
        hint = GameObject.Find("hint");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        Pos.y +=0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    setup = true;
                    if(backpack.GetComponent<BackPackItem>().treasure_key==true && isOpen == false){
                        fs.ReadTextFromResource("other 8");
                        isOpen = true;
                        backpack.GetComponent<BackPackItem>().treasure = true;
                        GetComponent<SpriteRenderer>().sprite = box_open;
                        Pos.y +=0.9f;
                        hint.transform.localPosition = Pos;

                    }else if(!isOpen){
                        fs.ReadTextFromResource("other 6");
                    }else{
                        fs.ReadTextFromResource("wrongbox");
                    }
                    
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("herb物體進入觸發器");
        
        hint.transform.localPosition = Pos;
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
