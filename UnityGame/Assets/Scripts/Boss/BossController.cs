using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtTopDown_Basic;
using Flower;
public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    float span=8.0f; //生成間隔
    float delta=0;

    float delta2=0;
    public GameObject moon_right;
    public GameObject moon_left;
    public GameObject star;
    Vector3 init_position = new Vector3(0, 46, 0);
    GameObject player;
    int randomNumber ;
    FlowerSystem fs;
    public float[] x={7.0f,-7.0f,0,0,3.5f,3.5f,-3.5f,-3.5f};
    public float[] y={0,0,7.0f,-7.0f,3.5f,-3.5f,3.5f,-3.5f};
    public float[] time={1.0f,1.3f,1.6f,1.9f,2.2f,2.5f,2.8f,3.1f};
    public int count = 0;
    public bool playing = false;
    void Start()
    {

        fs= FlowerManager.Instance.GetFlowerSystem("default");
        player = GameObject.Find("Player");
        gameObject.transform.position = init_position;
        delta2 = 100.0f;
        delta = 0;
        randomNumber = 0;
        fs.RegisterCommand("GoToBoss",(List<string> _params)=>{   
            playing = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playing){
            this.delta += Time.deltaTime;
            this.delta2 += Time.deltaTime;
            if(this.delta>this.span){
                
                System.Random random = new System.Random();
                randomNumber = random.Next(1, 4); // Generates a random number between 1 and 2
                if(randomNumber == 1){ //left
                    Vector3 target_position = player.GetComponent<Transform>().position;
                    target_position.x += 7;
                    gameObject.transform.position = target_position;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                
                }
                if(randomNumber == 2){ //right
                    Vector3 target_position = player.GetComponent<Transform>().position;
                    target_position.x -= 7;
                    gameObject.transform.position = target_position;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;

                }
                if(randomNumber == 3){ //star
                    count= 0;
                    for(int i=0;i<8;i++){
                        
                        GameObject go = Instantiate(star) as GameObject;
                        
                    }




                }

                this.delta = 0;
                this.delta2 = 0;
            }
            if(this.delta2>1.0f){
                if(randomNumber == 1){
                    GameObject go = Instantiate(moon_left) as GameObject;
                }
                if(randomNumber == 2){
                    GameObject go = Instantiate(moon_right) as GameObject;
                }
                this.delta2 = 10000.0f;
                randomNumber = 0;
            }
            

            
            if(this.delta>3.0f){
                gameObject.transform.position = init_position;
            }



            }
        
    }
}
