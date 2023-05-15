using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Boss", true);
        animator.Play("Banished");
      
        StartCoroutine(Boss());
    }
    public void Death()
    {
        animator.Play("muerte");
    }
    IEnumerator Boss()
    {
        yield return new WaitForSeconds(2f);
        animator.Play("Boss");
      
        animator.SetBool("Boss", false);
    }

}
