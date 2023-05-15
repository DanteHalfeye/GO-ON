using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInmunity controller = other.GetComponent<PlayerInmunity>();
        if (controller != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
