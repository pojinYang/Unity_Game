using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordGnerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sword;
    float span=1.0f; //生成間隔
    float delta=0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Return)&&this.delta>this.span){
            GameObject go = Instantiate(sword) as GameObject;
            this.delta=0;
        }
    }
}
