using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;
public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    FlowerSystem fs;
    public bool isReadMe = false;
    public GameObject readme0;
    public GameObject text0;
    public void Start()
    {
        readme0 = GameObject.Find("readme_square");
        text0 = GameObject.Find("Text");
    }


    public void playgame()
    {   
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);

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
}
