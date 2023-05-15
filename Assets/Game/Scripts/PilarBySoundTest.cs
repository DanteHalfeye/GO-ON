using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;
using System;

public class PilarBySoundTest : MonoBehaviour
{
    public float beatThreshold = 0.5f;
    public float beatInterval = 0.5f;
    public AudioSource audioSource;
    public Action OnBeatDetected;
    public bool beatDetected;
    [SerializeField] float nums = 0;

    private float lastBeatTime = 0f;
   
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        beatDetected = true;
    }
    void Update()
    {
        
        float energy = GetEnergy();
        if (energy > beatThreshold && Time.time - lastBeatTime > beatInterval)
        {
            print(energy);
            lastBeatTime = Time.time;
            beatDetected = true; // Set the bool to true
            OnBeatDetected?.Invoke(); // Invoke the event if it's not null
        }
        else
        {
            beatDetected = false; // Set the bool to false
        }

        if (beatDetected == true)
        {

            spawn = true;
        }
        else
        {
            spawn = false;
        }
        time -= Time.deltaTime;

        if (spawn)
        {
            spawnPilar();
            print("spawn");
        }
    }

    public float GetEnergy()
    {
        float[] spectrum = new float[256];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float sum = 0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            sum += spectrum[i];
        }
        return nums = sum * spectrum.Length;
    }
    public GameObject fallingPilarPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenbounds;
    private float time = 91f + 1f;
    public AudioClip bossSong;
    public float volume = 0.5f;
    public BossAnim bossAnim;
    public AudioClip explotion;
    public bool spawn = false;

  
    // Start is called before the first frame update

    private void spawnPilar()
    {
        GameObject a = Instantiate(fallingPilarPrefab) as GameObject;
        a.transform.position = new Vector2(UnityEngine.Random.Range(-screenbounds.x + 7, screenbounds.x + 9), screenbounds.y + 60);
    }
   
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
