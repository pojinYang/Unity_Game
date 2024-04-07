using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    float speed = 0.005f;
    float delta=0;
    // Start is called before the first frame update
    int num=0;
    float x=0;
    float y=0;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        
        num = GameObject.Find("Witch_Boss").GetComponent<BossController>().count++;
        x=GameObject.Find("Witch_Boss").GetComponent<BossController>().x[num] + player.GetComponent<Transform>().position.x;
        y=GameObject.Find("Witch_Boss").GetComponent<BossController>().y[num] + player.GetComponent<Transform>().position.y;
        gameObject.transform.position = new Vector3(x,y,0);
        delta = 0;  
    }

    // Update is called once per frame
    void Update()
    {   

        float a=-1*GameObject.Find("Witch_Boss").GetComponent<BossController>().x[num];
        float b=-1*GameObject.Find("Witch_Boss").GetComponent<BossController>().y[num];
        delta += Time.deltaTime;
        if(delta>GameObject.Find("Witch_Boss").GetComponent<BossController>().time[num]&&delta<6.0f){
            gameObject.transform.Translate(speed*a,speed*b,0);
        }
        
        if(delta>6.0f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
        Debug.Log("OnTriggerEnter");
    }

}
