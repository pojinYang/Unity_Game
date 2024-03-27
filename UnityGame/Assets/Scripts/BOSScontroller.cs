using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSScontroller : MonoBehaviour
{
    public GameObject Backpack;
    public GameObject player;
    public GameObject manual;
    public int timecounter; // 計時器
    // Start is called before the first frame update
    void Start()
    {
        Backpack = GameObject.Find("Backpack");
        player = GameObject.Find("Player");
        manual = GameObject.Find("manual"); // 遊玩說明
    }

    void ShowManual()
    {
        // 顯示Boss關卡遊玩說明
        manual.transform.localPosition = player.localPosition; // 將說明的位置設定為玩家位置
        manual.tramsform.localScale = new Vector3(10, 10, 10);  // 將說明顯示

    }
    void HideManual()
    {
        // 隱藏Boss關卡遊玩說明
        manual.tramsform.Scale = new Vector3(0, 0, 0);  // 將說明隱藏
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
