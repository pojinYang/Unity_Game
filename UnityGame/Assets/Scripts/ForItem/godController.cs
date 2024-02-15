using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
public class godController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
    bool setup = false;
    bool isEnd=false;
    // Start is called before the first frame update
    public bool GameOver = false;
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

            if(fs.isCompleted&&isEnd==false&&setup){
                // Debug.Log("isCompleted"); 
                
                fs.SetupButtonGroup();
                
                // 什麼都不燒 
                fs.SetupButton("......",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 27");
                });

                // 祭祀之火->火焰花
                if(backpack.GetComponent<BackPackItem>().fire){
                    fs.SetupButton("祭祀之火",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 23");
                    backpack.GetComponent<BackPackItem>().fire = false;
                    backpack.GetComponent<BackPackItem>().fire_flower = true;
                    });
                }
                
                // 火焰精華->植物精華
                if(backpack.GetComponent<BackPackItem>().fire_ginhua){
                    fs.SetupButton("火焰精華",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 24");
                    backpack.GetComponent<BackPackItem>().fire_ginhua = false;
                    backpack.GetComponent<BackPackItem>().plant_ginhua = true;
                    
                    });
                }

                // 灰燼->什覓草
                if(backpack.GetComponent<BackPackItem>().ash){
                    fs.SetupButton("灰燼",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 25");
                    backpack.GetComponent<BackPackItem>().ash = false;
                    backpack.GetComponent<BackPackItem>().herb = true;
                    
                    });
                }

                // 火箭->聖劍
                if(backpack.GetComponent<BackPackItem>().rocket){
                    fs.SetupButton("火箭",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 26");
                    backpack.GetComponent<BackPackItem>().rocket = false;
                    backpack.GetComponent<BackPackItem>().sword = true;
                    
                    });
                }

                // 放大鏡->線索
                if(backpack.GetComponent<BackPackItem>().magnifier){
                    fs.SetupButton("放大鏡",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("other 33");
                    backpack.GetComponent<BackPackItem>().clue_steal = 1;
                    
                    });
                }

                // 祕寶->通關
                if(backpack.GetComponent<BackPackItem>().treasure){
                    fs.SetupButton("祕寶",()=>{
                    //fs.Resume();
                    fs.RemoveButtonGroup();
                    fs.ReadTextFromResource("stage 23");
                    //  通關
                    GameOver = true;
                    });
                }

                isEnd = true;
                
            }




            if(Input.GetKeyDown(KeyCode.Space)){
                if(!setup){
                    setup = true;
                    fs.ReadTextFromResource("stage 24");
                    
                }
            }
        }
        if(fs.isCompleted&&GameOver){
            fs.RemoveDialog();
            Destroy(fs);
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("next2stair物體進入觸發器");
        Pos.y +=0.9f;
        hint.transform.localPosition = Pos;
        Pos.y -=0.9f;
        hint.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isNear = true;
        isEnd = false;
    }

    void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("next2stair物體離開觸發器");
        setup = false;
        isNear = false;
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
