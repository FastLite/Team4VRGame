using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class RadioScripts : MonoBehaviour
{
    public AudioSource radioSource;
    public List<AudioClip> trackList;
    public Slider slider;
    public TextMeshProUGUI trackName;

    

    public int currentTreck;

    private void Start()
    {
        Debug.Log(trackList.Count);
        currentTreck = Random.Range(0, trackList.Count);
        radioSource.clip = trackList[currentTreck];
        StartCoroutine("AutoPlayNextTrack");
        trackName.text = trackList[currentTreck].name;

    }
    public void ChangeAudioTime()
    {
        radioSource.time = radioSource.clip.length * slider.value;
    }
 
    public void Update()
    {
        slider.value = radioSource.time / radioSource.clip.length;
    }
    
    [ContextMenu("Next Track")]
    public void PlayNextTrack()
    {
        StopAllCoroutines();
        PlayTrack();
        StartCoroutine("AutoPlayNextTrack");
    }

    IEnumerator AutoPlayNextTrack()
    { 
        yield return new WaitForSeconds(trackList[currentTreck].length + 1);
        PlayTrack();
        
    }

    private void PlayTrack()
    {
        
        if (currentTreck + 1 == trackList.Count)
        {
            currentTreck = 0;
        }
        else
        {
            currentTreck++; 
        }
        
        radioSource.clip = trackList[currentTreck];
        radioSource.Play();
        trackName.text = trackList[currentTreck].name;

        StartCoroutine("AutoPlayNextTrack");
    }

    public void PauseResumeTrack()
    {
        
        if (radioSource.isPlaying)
        {
            radioSource.Pause();
        }
        else
        {
            radioSource.UnPause();
        }
        
    }

    public void StopPlay()
    {
        
        if (radioSource.isPlaying)
        {
            radioSource.Stop();
        }
        else
        {
            radioSource.Play();
        }


    }

    

}
