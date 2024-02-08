using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
public class next2stairController : MonoBehaviour
{
    public bool isNear = false;
    FlowerSystem fs;
    // Start is called before the first frame update
    
    void Start()
    {
        fs= FlowerManager.Instance.GetFlowerSystem("default");
    }

    // Update is called once per frame
    void Update()
    {
        //OnTriggerEnter;
    }
}
