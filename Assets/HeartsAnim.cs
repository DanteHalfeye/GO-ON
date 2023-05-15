using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsAnim : MonoBehaviour
{

    public bool heartOrShield = false;
    // Start is called before the first frame update
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heartOrShield)
        {
            Animator.Play("hearts");
        }
        if (heartOrShield == false)
        {
            Animator.Play("Shirelds");
        }
    }
}
