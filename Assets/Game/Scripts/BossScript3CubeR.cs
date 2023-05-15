using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript3CubeR : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private float time = 91f + 1f;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void Update()
    {
        time -= Time.deltaTime;
       

    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 60, Random.Range(-screenBounds.y + 35, screenBounds.y - 13));
    }
    IEnumerator asteroidWave()
    {
          yield return new WaitForSeconds(5);
        while (time > 0)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();

        }
    }
}
