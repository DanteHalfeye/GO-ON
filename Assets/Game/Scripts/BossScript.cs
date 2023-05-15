using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public GameObject fallingPilarPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenbounds;
    private float time = 91f + 1f;
    public AudioClip bossSong;
    public float volume = 0.5f;
    public BossAnim bossAnim;
    public AudioClip explotion;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      
        audioSource = GetComponent<AudioSource>();
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));  
        StartCoroutine(pilarWave());

    }
    private void Update()
    {
        time -= Time.deltaTime;
        Debug.Log(time);
    }
    private void spawnPilar()
    {
        GameObject a = Instantiate(fallingPilarPrefab) as GameObject;
        a.transform.position = new Vector2 (Random.Range(-screenbounds.x + 7, screenbounds.x + 9 )   , screenbounds.y + 60);
    }
IEnumerator pilarWave()
    {
        yield return new WaitForSeconds(5);
        PlaySound(bossSong);
        while (time > 0)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPilar();
        }
        yield return new WaitForSeconds(5f);
        bossAnim.Death();
        audioSource.PlayOneShot     (explotion);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
