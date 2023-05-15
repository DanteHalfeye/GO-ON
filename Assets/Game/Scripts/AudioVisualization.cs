using System;
using UnityEditor.Rendering;
using UnityEngine;

public class AudioVisualization : MonoBehaviour

{
    public float beatThreshold = 0.5f;
    public float beatInterval = 0.5f;
    public AudioSource audioSource;
    public Action OnBeatDetected;
    public bool beatDetected;
    [SerializeField] float nums = 0;

    private float lastBeatTime = 0f;
    PilarBySoundTest pilarBySoundTest = new PilarBySoundTest();
    public void Start()
    {
        beatDetected = true;
    }
    void Update()
    {
        
        float energy = GetEnergy();
        if (energy > beatThreshold && Time.time - lastBeatTime > beatInterval)
        {
            lastBeatTime = Time.time;
            beatDetected = true; // Set the bool to true
            OnBeatDetected?.Invoke(); // Invoke the event if it's not null
        }
        else
        {
            
        }

        if (beatDetected == true)
        {

            pilarBySoundTest.spawn = true;
        }
        else
        {
            pilarBySoundTest.spawn = false;
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
}