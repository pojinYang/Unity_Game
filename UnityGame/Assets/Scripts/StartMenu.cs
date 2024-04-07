using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;
using Cainos.PixelArtTopDown_Basic;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    FlowerSystem fs;
    public bool isReadMe = false;
    public GameObject readme0;
    public GameObject text0;
    public GameObject camera;
    public GameObject backpack;
    public GameObject player1;


    public void Awake(){

        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        backpack = GameObject.Find("Backpack");
        player1 = GameObject.Find("Player");
        fs.RegisterCommand("lock_player_start",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = false;
        });
        fs.RegisterCommand("unlock_player_start",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = true;
        });
        fs.RegisterCommand("release_player_start",(List<string> _params)=>{   
            player1.GetComponentInParent<TopDownCharacterController>().canPlayerMove = true;
        });
        
       
        fs.SetupDialog();
        fs.ReadTextFromResource("start_menu");

        //initial Flower System
        
        


    }
    
    public void Start()
    {
        camera.transform.localPosition = new Vector3(0,0,-10);
        readme0 = GameObject.Find("readme_square");
        text0 = GameObject.Find("Text");
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            fs.Next();   
    }



    public void playgame()
    {   
        

        SceneManager.LoadScene(1);
        

    }

    public void readme()
    {   
        if(isReadMe) isReadMe = false;
        else isReadMe = true;
        if(isReadMe){
            readme0.transform.localScale = new Vector3(11,9,0);
            text0.transform.localScale = new Vector3(1,1,1);
        }
        else{
            readme0.transform.localScale = new Vector3(0,0,0);
            text0.transform.localScale = new Vector3(0,0,0);
        } 
    }


    // Update is called once per frame
    public void Quitgame()
    {
           Application.Quit();
    }

    public void toAchievement(){
        
        if(camera.transform.localPosition.x == 0) camera.transform.localPosition = new Vector3(-50,0,-10);
        else{
            camera.transform.localPosition = new Vector3(0,0,-10);
        }
    }
}
