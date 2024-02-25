using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{


    public class TopDownCharacterController : MonoBehaviour
    {
        public bool isHit = false;
        public float speed;
        public bool canPlayerMove = true ;

        private Animator animator;
        public Vector2 dir = Vector2.zero;
        Stack<char> move = new Stack<char>();

        private void Start()
        {
            animator = GetComponent<Animator>();
            move.Clear();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            
            // 後出現的指令會先被執行(使用stack模擬)
            if(canPlayerMove){
                if (Input.GetKeyDown(KeyCode.A))
                {
                    move.Push('A');
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    move.Push('D');
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    move.Push('W');
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    move.Push('S');
                }
                while(true){
                    if(move.Count == 0) break;
                    
                    if(move.Peek() == 'A' && Input.GetKey(KeyCode.A)){
                        dir.x = -1;
                        animator.SetInteger("Direction", 3);
                    }
                    else if(move.Peek() == 'D' && Input.GetKey(KeyCode.D)){
                        dir.x = 1;
                        animator.SetInteger("Direction", 2);
                    }
                    else if(move.Peek() == 'W' && Input.GetKey(KeyCode.W)){
                        dir.y = 1;
                        animator.SetInteger("Direction", 1);
                    }
                    else if(move.Peek() == 'S' && Input.GetKey(KeyCode.S)){
                        dir.y = -1;
                        animator.SetInteger("Direction", 0);
                    }else{
                        move.Pop();
                    }
                    break;
                    
                }
            }else{
                dir.x = 0;
            }




            // 隨意移動版
            // if(canPlayerMove){
            //     if (Input.GetKey(KeyCode.A))
            //     {
            //         dir.x = -1;
            //         animator.SetInteger("Direction", 3);
            //     }
            //     if (Input.GetKey(KeyCode.D))
            //     {
            //         dir.x = 1;
            //         animator.SetInteger("Direction", 2);
            //     }
            //     if (Input.GetKey(KeyCode.W))
            //     {
            //         dir.y = 1;
            //         animator.SetInteger("Direction", 1);
            //     }
            //     if (Input.GetKey(KeyCode.S))
            //     {
            //         dir.y = -1;
            //         animator.SetInteger("Direction", 0);
            //     }
            // }else{
            //     dir.x = 0;
            // }












            // 預設原版
            // if(!canPlayerMove)
            // {
            //     dir.x = 0;
            // }
            // else if (Input.GetKey(KeyCode.A))
            // {
            //     dir.x = -1;
            //     animator.SetInteger("Direction", 3);
            // }
            // else if (Input.GetKey(KeyCode.D))
            // {
            //     dir.x = 1;
            //     animator.SetInteger("Direction", 2);
            // }

            // else if (Input.GetKey(KeyCode.W))
            // {
            //     dir.y = 1;
            //     animator.SetInteger("Direction", 1);
            // }
            // else if (Input.GetKey(KeyCode.S))
            // {
            //     dir.y = -1;
            //     animator.SetInteger("Direction", 0);
            // }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            
            isHit = true;
            Debug.Log("Hit");
            
        }
    }
    

    
}
