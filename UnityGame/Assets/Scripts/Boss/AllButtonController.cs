using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
public class AllButtonController : MonoBehaviour
{
    public int HP=10;
    public int shield = 3;
    public int[] NumberofLighting = {0,0,0,0,0};
    GameObject button;
    FlowerSystem fs;
    // Start is called before the first frame update
    public int[] ButtonColor = {1,1,2,2,3,3,4,4};
    GameObject player;
    public void reset(){
        for(int i=0;i<5;i++){
            NumberofLighting[i] = 0;
        }
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
        player = GameObject.Find("Player");
        fs = FlowerManager.Instance.GetFlowerSystem("default");
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
        
        if(NumberofLighting[1] == 2){ //red
            reset();
            HP--;
        }
        else if(NumberofLighting[2] == 2){ //blue
            reset();
            //colliderOFF
        }
        else if(NumberofLighting[3] == 2){//yellow
            reset();
            shield--;
        }
        else if(NumberofLighting[4] == 2){//purple
        reset();
            HP++;
            shield=3;
        }
        if(HP<=0){
            HP=100;
            //gameover
            GameObject.Find("Witch_Boss").GetComponent<BossController>().playing=false;
            
            player.transform.position = new Vector3(-4.47f,-30.4f,0);
            fs.ReadTextFromResource("stage 22");

        }

        
        
    }
    
}
