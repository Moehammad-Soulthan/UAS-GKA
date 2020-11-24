using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManage : MonoBehaviour
{
    public AudioClip popsound;
    public AudioSource AudioSource;

    public AudioClip closesound;
    public AudioSource AudioSource2;

    public AudioClip background;
    public AudioSource AudioSource3;

    void Start()
    {
        AudioSource.clip = popsound;
        AudioSource2.clip = closesound;
        AudioSource3.clip = background;
        AudioSource3.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPop()
    {
        AudioSource.Play();
    }

    public void playClosesound()
    {
        AudioSource2.Play();
    }


}
