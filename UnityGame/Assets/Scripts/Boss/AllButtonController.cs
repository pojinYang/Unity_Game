using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllButtonController : MonoBehaviour
{
    GameObject button;
    // Start is called before the first frame update
    public int[] ButtonColor = {1,1,2,2,3,3,4,4};
    public void reset(){
        
        gameObject.transform.GetChild(0).GetComponent<Stone_buttom0>().turnColor(0);
        gameObject.transform.GetChild(1).GetComponent<Stone_buttom1>().turnColor(0);
        gameObject.transform.GetChild(2).GetComponent<Stone_buttom2>().turnColor(0);
        gameObject.transform.GetChild(3).GetComponent<Stone_buttom3>().turnColor(0);
        gameObject.transform.GetChild(4).GetComponent<Stone_buttom4>().turnColor(0);
        gameObject.transform.GetChild(5).GetComponent<Stone_buttom5>().turnColor(0);
        gameObject.transform.GetChild(6).GetComponent<Stone_buttom6>().turnColor(0);
        gameObject.transform.GetChild(7).GetComponent<Stone_buttom7>().turnColor(0);


        System.Random rand = new System.Random();
        for (int i = ButtonColor.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temp = ButtonColor[i];
            ButtonColor[i] = ButtonColor[j];
            ButtonColor[j] = temp;
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
        if(gameObject.transform.GetChild(0).GetComponent<Stone_buttom0>().islight)
            gameObject.transform.GetChild(0).GetComponent<Stone_buttom0>().turnColor(ButtonColor[0]);
        if(gameObject.transform.GetChild(1).GetComponent<Stone_buttom1>().islight)
            gameObject.transform.GetChild(1).GetComponent<Stone_buttom1>().turnColor(ButtonColor[1]);
        if(gameObject.transform.GetChild(2).GetComponent<Stone_buttom2>().islight)
            gameObject.transform.GetChild(2).GetComponent<Stone_buttom2>().turnColor(ButtonColor[2]);
        if(gameObject.transform.GetChild(3).GetComponent<Stone_buttom3>().islight)
            gameObject.transform.GetChild(3).GetComponent<Stone_buttom3>().turnColor(ButtonColor[3]);
        if(gameObject.transform.GetChild(4).GetComponent<Stone_buttom4>().islight)
            gameObject.transform.GetChild(4).GetComponent<Stone_buttom4>().turnColor(ButtonColor[4]);
        if(gameObject.transform.GetChild(5).GetComponent<Stone_buttom5>().islight)
            gameObject.transform.GetChild(5).GetComponent<Stone_buttom5>().turnColor(ButtonColor[5]);
        if(gameObject.transform.GetChild(6).GetComponent<Stone_buttom6>().islight)
            gameObject.transform.GetChild(6).GetComponent<Stone_buttom6>().turnColor(ButtonColor[6]);
        if(gameObject.transform.GetChild(7).GetComponent<Stone_buttom7>().islight)
            gameObject.transform.GetChild(7).GetComponent<Stone_buttom7>().turnColor(ButtonColor[7]);
        
        
        
    }
    
}
