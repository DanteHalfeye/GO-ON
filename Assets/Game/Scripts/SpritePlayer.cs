using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    bool walking = false;
    bool damaged = false;
    bool wallJump = false;
    bool notwallJump = false;
    bool wallHanging = false;
    bool onAir = false;

    int canInvencible = 3;
    SpriteRenderer spriteRenderer;
    public PlayerInmunity player;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        PlayerInmunity player = GetComponent<PlayerInmunity>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("GetInvulnerable3");

        }

        if (damaged)
        {
            animator.Play("Damaged");
           
        }
        else
        {
            if (wallHanging && notwallJump == false)
            {
                animator.Play("WallJump");
            }
            
            else
                
           
            {
              
                if (onAir == true && Input.GetButton("Fire3"))
               
                {
               
                    animator.Play("OnAirC"); 
               
                }
              
                else
              
                {

               

                 
                    if (onAir == true)
           

                    {
            
                        animator.Play("OnAir");
            
                    }
            
                    else
           
                    {


              
                
                   
                        if (Input.GetButton("Fire3") && walking == true)
                   
                        {
                   
                            animator.Play("CrouchWalk");
                    
                        }

                    
                        else
                   
                        {
                        
                            if (Input.GetButton("Fire1") && walking == true)
                       
                            {
                         
                                animator.Play("RunMax");

                       
                            }
                       
                            else
                       
                            {


                           
                                if (walking == true)
                           
                                {
                            
                                    animator.Play("walk");
                           
                                }


                           
                                else
                           
                                {
                               
                                    if (Input.GetButton("Fire3"))

                                    {

                                        animator.Play("IdleMax");

                                    }

                                
                                    else
                                
                                    {

                                    animator.Play("Crouch");
                               
                                    }

                           
                                }


                           
                            }
                        
                        }
                   
                    } 
                }
            }

        }




    }
    public void OnaAir()
    {
     
        onAir = true;
       
    }
    public void NonOnaAir()
    {
       
        onAir = false;

    }
    public void Walking()
    {
        walking = true;
       

    }
    public void NotWalking()
    {
        walking = false;
        

    }

    public void WallJump()
    {
        StartCoroutine(WallJumping());
        

    }
    public void NotWallJump()
    {
        wallHanging = false;
        notwallJump = false;
        
        player.NotWallJump1();

    }
    public void WallHanging()
    {
        wallHanging = true;
        

    }


    IEnumerator WallJumping()
    {
        wallJump = true;
        if (wallHanging == true && wallJump == true)
        {
            
            notwallJump = false;
            player.WallJump1();
            yield return new WaitForSeconds(0.1f);
            wallJump = false;
        }
        

    }
        public void Ps()
    {
        StartCoroutine(GetInvulnerable4());
       

    }

    IEnumerator GetInvulnerable4()
    {
        damaged = true;
        yield return new WaitForSeconds(2f);
        damaged = false;


    }

    IEnumerator GetInvulnerable3()
    {
        if (canInvencible > 0)
        {
            
            spriteRenderer.color = new Color(.0f, 255.0f, 255.0f, 1f);
            yield return new WaitForSeconds(2f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            canInvencible = canInvencible - 1;
        }
        


    }
}
