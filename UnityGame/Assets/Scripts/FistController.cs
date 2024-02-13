using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistController : MonoBehaviour
{
    // Start is called before the first frame update
    int dir;
    public float speed = 0.03f;
    GameObject player;
    void Start()
    {
        
        dir = Random.Range(1, 5);
        
        if(dir==1||dir==2){
            int x=Random.Range(-190, -183);
            if(dir==1){
                transform.position = new Vector3(x, 0, 0);
            }else{
                transform.position = new Vector3(x, -20, 0);
            
            }
        }else{
            int y=Random.Range(-15, -6);
            if(dir==3){
                transform.position = new Vector3(-206, y, 0);
            }else{
                transform.position = new Vector3(-176, y, 0);
            
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(randomNumber);
        if(dir==1){
            transform.Translate(0,-1*speed,0);
            if(transform.position.y<-20){
                Destroy(gameObject);
            }
        }else if(dir==2){
            transform.Translate(0,speed,0);
            if(transform.position.y>0){
                Destroy(gameObject);
            }
        }else if(dir==3){
            transform.Translate(speed,0,0);
            if(transform.position.x>-176){
                Destroy(gameObject);
            }
        }else{
            transform.Translate(-1*speed,0,0);
            if(transform.position.x<-206){
                Destroy(gameObject);
            }
        }



        
    }

        // Add collision detection code here
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("OnCollisionEnter");

    }

    


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Ghost_Game").GetComponent<fistGenerator>().isHit=true;
        GameObject.Find("Backpack").GetComponent<BackPackItem>().Ghost_Game1=2;

        Destroy(gameObject);
        Debug.Log("OnTriggerEnter");
    }

}
    





