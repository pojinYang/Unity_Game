using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Vector3 pos;
    int dir ;
    // Start is called before the first frame update
    public float speed = 0.03f;
    void Start()
    {
        pos = GameObject.Find("Player").transform.localPosition;
        dir = GameObject.Find("Player").GetComponent<Animator>().GetInteger("Direction");
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir==0){
            transform.Translate(0,-0.5f*speed,0);
            if(transform.position.y<-20){
                Destroy(gameObject);
            }
        }else if(dir==1){
            transform.Translate(0,0.5f*speed,0);
            if(transform.position.y>0){
                Destroy(gameObject);
            }
        }else if(dir==2){
            transform.Translate(0.5f*speed,0,0);
            if(transform.position.x>-176){
                Destroy(gameObject);
            }
        }else{
            transform.Translate(-0.5f*speed,0,0);
            if(transform.position.x<-206){
                Destroy(gameObject);
            }
        }
    }
}
