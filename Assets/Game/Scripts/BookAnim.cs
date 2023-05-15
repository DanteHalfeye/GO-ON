using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnim : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.Play("FlyingBook");
    }
}
