using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_buttom : MonoBehaviour
{
    // 更改數值以完成按鈕
    void Start()
    {
        
    }

    void turnColor(int c){ //轉變顏色 0灰色 1紅色 2藍色 3黃色 4紫色
        if(c == 0){
            this.gameObject.GetComponent<SpriteRanderer>().color = new Color(255, 255, 255, 255);
        }
        if(c == 1){
            this.gameObject.GetComponent<SpriteRanderer>().color = new Color(255, 111, 76, 255);
        }
        if(c == 2){
            this.gameObject.GetComponent<SpriteRanderer>().color = new Color(0, 167, 255, 255);
        }
        if(c == 3){
            this.gameObject.GetComponent<SpriteRanderer>().color = new Color(255, 255, 0, 255);
        }
        if(c == 4){
            this.gameObject.GetComponent<SpriteRanderer>().color = new Color(191, 0, 255, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
