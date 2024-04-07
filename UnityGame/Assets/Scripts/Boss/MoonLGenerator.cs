using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLGenerator : MonoBehaviour
{
     float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
                transform.localPosition = GameObject.Find("Witch_Boss").GetComponent<Transform>().localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1*speed,0,0);
        if(transform.position.x<-19){
            Destroy(gameObject);
        }


    }
        void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
        Debug.Log("OnTriggerEnter");
    }


}

