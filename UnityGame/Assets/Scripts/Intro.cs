using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEditor.Build.Content;
using Cainos.PixelArtTopDown_Basic;
public class Intro : MonoBehaviour

    
{
    // Start is called before the first frame update
    FlowerSystem fs;
   
    public GameObject player1;
    public GameObject backpack;
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
            backpack.GetComponent<BackPackItem>().stage =int.Parse(_params[0]) ;
        });
        /*fs.RegisterCommand("play_game",(List<string> _params)=>{   
            
        });*/

        fs.ReadTextFromResource("stage intro");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            fs.Next();
        }
    }
}
