using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManage : MonoBehaviour
{
    public Button musicbuttonstop, musicbuttonplay;

    public AudioClip popsound;
    public AudioSource AudioSource;

    public AudioClip closesound;
    public AudioSource AudioSource2;

    public AudioClip backsoundingame;
    public AudioSource AudioSource3;

    public AudioClip backsoundinmenu;
    public AudioSource AudioSource4;

    void Start()
    {
        AudioSource.clip = popsound;
        AudioSource2.clip = closesound;
        AudioSource3.clip = backsoundingame;
        AudioSource4.clip = backsoundinmenu;
        AudioSource3.Play();
        AudioSource4.Play();

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

    public void  playgamebacksound()
    {
        AudioSource3.Play();
        
    }

    public void playmenubacksound()
    {
        AudioSource4.Play();
    }

    public void pausegamebacksound()
    {
        AudioSource3.Pause();
    }

    // public void stopmusic()
    // {
    //     AudioSource3.Pause();
    //     AudioSource4.Pause();
    // }

    // public void playmusic()
    // {
    //     AudioSource3.Play();
    //     AudioSource4.Play();
    // }

    // public void musicplayactive()
    // {
    //     musicbuttonplay.enabled = true;
    //     musicbuttonstop.enabled = false;
    // }

    // public void musicstopactive()
    // {
    //    musicbuttonplay.enabled = false;
    //     musicbuttonstop.enabled = true;
    // }

}
