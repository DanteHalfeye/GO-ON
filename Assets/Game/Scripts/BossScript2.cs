using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript2 : MonoBehaviour
{
    public GameObject fallingPilarPrefab;
    public float respawnTime = 6.0f;
    private Vector2 screenbounds;
    private float time = 91f + 1f;
    public AudioClip areyouready;
    public float volume = 0.5f;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(pilarWave());
        StartCoroutine(areYouReady());

    }
    private void Update()
    {
        time -= Time.deltaTime;
       
    }
    private void spawnPilar()
    {
        GameObject a = Instantiate(fallingPilarPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenbounds.x + 7, screenbounds.x + 9), screenbounds.y + 60);
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
    IEnumerator areYouReady()
    {
        yield return new WaitForSeconds(3);
        PlaySound(areyouready);

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}
