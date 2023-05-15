using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSong : MonoBehaviour
{
    public AudioSource AudioSource;

    // Start is called before the first frame update

  
    void Start()
    {
        AudioSource.Play();
    }

    

}
