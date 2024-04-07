using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllButtonController : MonoBehaviour
{
    GameObject button;
    // Start is called before the first frame update
    int[] ButtonColor = {1,1,2,2,3,3,4,4};
    public void reset(){
        for(int i = 0; i < 8; i++){
            gameObject.transform.GetChild(i).GetComponent<Stone_buttom>().turnColor(0);
        }
        System.Random rand = new System.Random();
        for (int i = ButtonColor.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temp = ButtonColor[i];
            ButtonColor[i] = ButtonColor[j];
            ButtonColor[j] = temp;
        }
        for(int i = 0; i < 8; i++){
            Debug.Log(ButtonColor[i]);
        }

    }
    void Start()
    {
        button = gameObject.transform.GetChild(0).gameObject;
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
            gameObject.transform.GetChild(0).gameObject.GetComponent<Stone_buttom>().turnColor(1);
        if(Input.GetKeyDown(KeyCode.I))  
            gameObject.transform.GetChild(0).gameObject.GetComponent<Stone_buttom>().turnColor(2);    
    }
    
}
