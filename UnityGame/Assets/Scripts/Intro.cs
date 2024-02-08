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
    void Start()
    {
        player1 = GameObject.Find("Player");
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();

        //initial Flower System
        fs.ReadTextFromResource("intro");
        fs.RegisterCommand("lock_player",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = false;
        });
        fs.RegisterCommand("unlock_player",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            fs.Next();
        }
    }
}
