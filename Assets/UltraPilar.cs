using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraPilar : MonoBehaviour
{
    public GameObject fallingPilarPrefab;
    public float respawnTime = 6.0f;
    private Vector2 screenbounds;
    private float time = 83f;
    private float UnoAlTres = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(pilarWave());
      

    }
    private void Update()
    {
        time -= Time.deltaTime;

    }
    private void spawnPilar()
    {

        UnoAlTres++;
        GameObject a = Instantiate(fallingPilarPrefab) as GameObject;
        switch (UnoAlTres)
        {
            case 1:
                a.transform.position = new Vector2(10.32524f, screenbounds.y + 60);
                Debug.Log("1");
                break;
            case 2:
                a.transform.position = new Vector2(23.74f, screenbounds.y + 60);
                Debug.Log("2");
                break;  
            case 3:
                a.transform.position = new Vector2(-3.91f, screenbounds.y + 60);
                UnoAlTres = 0;
                Debug.Log("3");
                break;
                
            
        }

    }
    // Update is called once per frame
    IEnumerator pilarWave()
    {
        yield return new WaitForSeconds(5);

        while (time > 0)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPilar();
        }
    }
    
 



}
