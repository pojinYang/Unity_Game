using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordGnerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sword;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            GameObject go = Instantiate(sword) as GameObject;
        }
    }
}
