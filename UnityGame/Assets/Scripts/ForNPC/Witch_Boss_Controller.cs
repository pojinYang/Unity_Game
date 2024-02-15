using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch_Boss_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        
        GameObject.Find("Backpack").GetComponent<BackPackItem>().Ghost_Game1=2;
        
        Debug.Log("Boss 被打");
    }
    
}
