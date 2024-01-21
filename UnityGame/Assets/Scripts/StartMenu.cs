using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Quitgame()
    {
           Application.Quit();
    }
}
