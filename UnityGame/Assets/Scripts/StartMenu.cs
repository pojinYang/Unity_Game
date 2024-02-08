using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;
public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    FlowerSystem fs;
    public void playgame()
    {   
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);

        SceneManager.LoadScene(1);
        

    }

    // Update is called once per frame
    public void Quitgame()
    {
           Application.Quit();
    }
}
