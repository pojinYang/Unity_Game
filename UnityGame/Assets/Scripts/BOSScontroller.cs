using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSScontroller : MonoBehaviour
{
    public GameObject Backpack;
    public GameObject player;
    public int timecounter; // 計時器
    // Start is called before the first frame update
    void Start()
    {
        Backpack = GameObject.Find("Backpack");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
