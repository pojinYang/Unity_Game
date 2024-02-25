using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Flower;

using Cainos.PixelArtTopDown_Basic;
public class Intro : MonoBehaviour
{


    // Start is called before the first frame update
    FlowerSystem fs;
   
    public GameObject player1;
    public GameObject backpack;
    public SpriteRenderer rawImage = new SpriteRenderer();

    public SpriteRenderer BackImage;
    /*public float AppearTime = 5f;//展示的时间
    public float AppearTimeTrigger = 0f;//
    public float FadeTime = 3f;
    public float FadeTimeTrigger = 0f;
    
*/
    public float fadeSpeed = 1;
    public bool Show = false;
    bool isActive = false;
    void Start()
    {
        backpack = GameObject.Find("Backpack");
        player1 = GameObject.Find("Player");
        fs= FlowerManager.Instance.GetFlowerSystem("default");
        fs.SetupDialog();

        //initial Flower System
        
        fs.RegisterCommand("lock_player",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = false;
        });
        fs.RegisterCommand("unlock_player",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = true;
        });
            fs.RegisterCommand("release_player",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = true;
        });
        fs.RegisterCommand("next_stage",(List<string> _params)=>{   
            backpack.GetComponent<BackPackItem>().stage =int.Parse(_params[0]) ;//some Q
        });
        fs.RegisterCommand("play_game",(List<string> _params)=>{   
            backpack.GetComponent<BackPackItem>().stage = 0;
        });
        fs.RegisterCommand("showimage",(List<string> _params)=>{   
            GameObject target;
            target = GameObject.Find(_params[0]); // some Q
            rawImage=target.GetComponent<SpriteRenderer>();
            target.transform.localPosition = player1.transform.localPosition;
            target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            Show = true;
            isActive = true;
        });
        fs.RegisterCommand("hideimage",(List<string> _params)=>{   
            GameObject target;
            target = GameObject.Find(_params[0]);
            target.transform.localScale = new Vector3(0, 0, 0);
            
            Show = false;
        });

        fs.ReadTextFromResource("stage intro");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        /*AppearTimeTrigger += Time.deltaTime;
        if (AppearTimeTrigger > AppearTime)
            {
        if (FadeTimeTrigger >= 0 && FadeTimeTrigger < FadeTime)
        {
            FadeTimeTrigger += Time.deltaTime;
            if (Show)
            {

                BackImage.color = new Color(1, 1, 1, 1 - (FadeTimeTrigger / FadeTime));//淡出
            }
            else
            {
                BackImage.color = new Color(1, 1, 1, (FadeTimeTrigger / FadeTime));//淡入
            }
        }
    }*/
    /*if(isActive){

        if(Show == false){

                rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
                if (rawImage.color.a < 0.1f)
                    {
                        rawImage.color = Color.clear;
                    }
            }else{
                rawImage.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(1, 1, 1, 1), Time.deltaTime * fadeSpeed);//漸暗
                    if (rawImage.color.a > 0.9f)
                    {
                        rawImage.color = new Color(1, 1, 1, 1);
                    }

            }


    }*/
    



        if(Input.GetKeyDown(KeyCode.Space)){
            fs.Next();
        }
    }
}
