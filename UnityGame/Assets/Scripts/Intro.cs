using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEditor.Build.Content;

public class Intro : MonoBehaviour

    
{
    // Start is called before the first frame update
    FlowerSystem fs;

    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        //initial Flower System
        fs.ReadTextFromResource("intro");
        /*fs.RegisterCommand("lock_player",(List<string>_params)=>{   
            GameManager.instance.playerObject.GetComponent<PlayerContoller>().
        })*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            fs.Next();
        }
    }
}