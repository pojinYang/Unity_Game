using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fistGenerator : MonoBehaviour
{
    public GameObject fist;
    float span=1.0f; //生成間隔
    float delta=0;
    public bool isHit=false; 
    public int times=0;
    // Start is called before the first frame update
    public void Init()
    {
        
    }

    // Update is called once per frame
    public void Playing()
    {
        if(times>10){
            GameObject.Find("Backpack").GetComponent<BackPackItem>().Ghost_Game1=2;
        }
        this.delta += Time.deltaTime;
        if(this.delta>this.span){
            this.delta=0;
            for(int i=0;i<3;i++){
                GameObject go = Instantiate(fist) as GameObject;
            }
                
            times++;
            
        }
    }
}
