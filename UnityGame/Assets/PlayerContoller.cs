using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initial_position = new Vector3 (-1f, -3.5f ,0f);
    GameObject Camera;
    void Start() {
        this.Camera = GameObject.Find("Main Camera");
        this.Camera.transform.position = new Vector3(0, 0, -10);
        transform.position = initial_position;
    }

    // Update is called once per frame
    void Update() {
        float player_speed = 0.1f;

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0, player_speed, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0,-player_speed, 0);
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(player_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-player_speed, 0, 0);
        }
    }
}
