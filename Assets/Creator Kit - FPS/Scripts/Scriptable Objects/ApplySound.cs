using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ApplySound : MonoBehaviour
{ 
    AudioSource _AudioSource;
    [SerializeField] private SingleSoundSO soundObject;
    public bool PlayOnAwake = false;
    public bool Loop = false;

    private void Awake()
    {
        _AudioSource = gameObject.GetComponent<AudioSource>();
        soundObject.GetParameters();
        _AudioSource.clip = soundObject.myAudioClip;
        _AudioSource.pitch = soundObject.pitch;
        _AudioSource.volume = soundObject.volume;
        
        _AudioSource.outputAudioMixerGroup = soundObject.audioMixerGroup;
        _AudioSource.playOnAwake = PlayOnAwake;
        _AudioSource.loop = Loop;
        if (PlayOnAwake)
        {
            _AudioSource.Play();
        }
    }

    private void Start()
    {
       
    }
}
