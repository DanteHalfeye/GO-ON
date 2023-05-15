using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Script : BossDamage
{

    [SerializeField] float moveSpeed = 1f;
    bool bossIA = false;
    public AudioSource audioSource;
    Rigidbody2D myRigidbody;
    public AudioClip Rugido;
    public AudioClip musica;
    public AudioClip death;
    public Animator animator;
    bool starting = false;

    // Start is called before the first frame update
    void Start()
    {
        starting = true;
        audioSource = GetComponent<AudioSource>();
        myRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine (moveandstop());
    }

    // Update is called once per frame
    void Update()
    {
        if (bossIA)
        {
            animator.Play("Boss2Sfight");
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
           
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, 0f);
            if (starting == false)
            {
                animator.Play("Boss2Death");
            }
        }

    }
    IEnumerator moveandstop()
    {
        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(Rugido);
        yield return new WaitForSeconds(3);
        
     bossIA =  true;
        audioSource.PlayOneShot(musica);
        yield return new WaitForSeconds(68);
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        bossIA = false;
        starting = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
