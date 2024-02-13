using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WitchController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    bool setup = false;
    public bool GameOver = false;
    GameObject hint;
    GameObject backpack;
    Vector3 Pos = new Vector3(0, 0, 0);
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

                    if(backpack.GetComponent<BackPackItem>().stage<5){
                        fs.ReadTextFromResource("other 12");
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==5){
                        fs.ReadTextFromResource("stage 6");
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==6){
                        //fs.ReadTextFromResource("other");
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==7){
                        fs.ReadTextFromResource("stage 7");
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==8 && backpack.GetComponent<BackPackItem>().herb==true){ //還沒做要不要給巫師的選項內容
                        fs.ReadTextFromResource("stage 9");
                        backpack.GetComponent<BackPackItem>().herb = false;
                    }
                    
                    if(backpack.GetComponent<BackPackItem>().stage==10 && backpack.GetComponent<BackPackItem>().fire==true){  //還沒做要不要給巫師的選項內容
                        fs.ReadTextFromResource("stage 17");
                        backpack.GetComponent<BackPackItem>().fire=false;
                        GameOver = true;
                    }
                    if(backpack.GetComponent<BackPackItem>().stage==9 && backpack.GetComponent<BackPackItem>().stone_plate==true){  //還沒做要不要給巫師的選項內容
                        fs.ReadTextFromResource("stage 12");
                        backpack.GetComponent<BackPackItem>().stone_plate=false;
                        backpack.GetComponent<BackPackItem>().stage = 10;
                    }


                }else{

                    fs.Next();
                    if(fs.isCompleted&&GameOver){
                        fs.RemoveDialog();
                        Destroy(fs);
                        SceneManager.LoadScene(0);
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
        

        isNear = false;
        setup = false;
        
        hint.transform.localScale = new Vector3(0, 0, 0);
    }
}
