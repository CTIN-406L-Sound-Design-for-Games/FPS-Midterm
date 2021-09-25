using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ApplySound : MonoBehaviour
{ 
    AudioSource _AudioSource;
    [SerializeField] private SingleSoundSO soundObject;

    private void Awake()
    {
        _AudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        _AudioSource.clip = soundObject.myAudioClip;
        _AudioSource.outputAudioMixerGroup = soundObject.audioMixerGroup;
    }
}
