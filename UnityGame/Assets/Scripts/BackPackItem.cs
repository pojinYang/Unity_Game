using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool invisible_lens = false; //隱形眼鏡  //燒不了
    public bool herb = false;  //藥材  
    public bool stone_plate = false;  //石板
    public bool fire_flower = false;  //火焰花
    public bool plant_ginhua = false;  //植物精華
    public bool fire = false;  //祭祀之火
    public bool treasure = false;  //祕寶
    public bool sword = false; //聖劍 
    public bool sword_key = false;   //燒不了
    public bool treasure_key = false;    //燒不了
    public bool ash = false;
    public bool fire_ginhua = false;  //火焰精華
    public bool rocket = false; //火箭

    public int stage;
    public int stage2;
    void Start()
    {
        stage = 1;
        stage2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
