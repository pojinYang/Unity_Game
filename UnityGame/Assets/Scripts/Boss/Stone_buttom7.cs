using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_buttom7 : MonoBehaviour
{
    public static int Color_num = 7;
    public bool islight = false;
    void Start()
    {
        islight = false;
    }

    public void turnColor(int c){ //轉變顏色 0灰色 1紅色 2藍色 3黃色 4紫色
        if(c == 0){
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        if(c == 1){
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 111, 76, 255);
        }
        if(c == 2){
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 167, 255, 255);
        }
        if(c == 3){
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);
        }
        if(c == 4){
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(191, 0, 255, 255);
        }
        Debug.Log("turnColor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
       islight = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        
    }

}
