using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{   
    [HideInInspector]
    public bool isBlack = false;//不透明狀態
    [HideInInspector]
    public float fadeSpeed = 1;//透明度變化速率
    public RawImage rawImage;
    public RectTransform rectTransform;

    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);//使背景滿屏
        rawImage.color = Color.clear;
    }

    void Update()
    {
        if (isBlack == false)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);//漸亮
            //之所以這麼寫主要是因爲Lerp函數的原因，具體詳解可以看這篇文章
            //【Unity中Lerp的用法】https://blog.csdn.net/MonoBehaviour/article/details/79085547
            if (rawImage.color.a < 0.1f)
            {
                rawImage.color = Color.clear;
            }
        }
        else if (isBlack)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, Time.deltaTime * fadeSpeed);//漸暗
            if (rawImage.color.a > 0.9f)
            {
                rawImage.color = Color.black;
            }
        }
    }

    //切換狀態
    public void BackGroundControl(bool b)
    {
        if (b == true)
            isBlack = true;
        else
            isBlack = false;
    }
    
}
