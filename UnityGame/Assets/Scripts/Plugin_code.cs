using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build.Content;
using Cainos.PixelArtTopDown_Basic;

public class Plugin_code : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            player.GetComponentInParent<TopDownCharacterController>().speed = 7.0f;
            player.GetComponentInParent<BoxCollider2D>().isTrigger = true;
        }
        if(Input.GetKeyUp(KeyCode.F)){
            player.GetComponentInParent<TopDownCharacterController>().speed = 3.0f;
            player.GetComponentInParent<BoxCollider2D>().isTrigger = false;
        }
    }
}
