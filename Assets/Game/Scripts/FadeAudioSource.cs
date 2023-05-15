using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudioSource : MonoBehaviour

{
    public  AudioSource soudtrackAudioSource;
    private float fadeTime = 2f;
    private float time = 94f;
    bool time1 = false;
    bool time2 = false;


 
    public  IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {

        float startVolume = audioSource.volume;
      
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Time2();

    }
    void Start()
    {
        soudtrackAudioSource = GetComponent<AudioSource>();
    }
    void Time2()
    {
        soudtrackAudioSource.Stop();
        time2 = true;

    }
 
    
    void Update()
    {
        time -= Time.deltaTime;

        while (time < 0 && time1 == false)
        {
            //StartCoroutine(FadeOut(soudtrackAudioSource, 0.1f));
            time1 = true;
            StartCoroutine(FadeOut(soudtrackAudioSource, fadeTime));
            
        }
        if (time2)
        {
            soudtrackAudioSource.volume = 1;
        }





    }

}