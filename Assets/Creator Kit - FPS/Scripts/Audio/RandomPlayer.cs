using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class RandomPlayer : MonoBehaviour
{
   
    private AudioClip[] Clips;
    private float PitchMin = 1.0f;
    private float PitchMax = 1.0f;
    [SerializeField]private SoundSO soundObject;

    public AudioSource source => m_Source;

    AudioSource m_Source;

    void Awake()
    {
        if (soundObject)
            Clips = soundObject.myAudioClips;
        m_Source = GetComponent<AudioSource>();
        if (soundObject.audioMixerGroup)
            m_Source.outputAudioMixerGroup = soundObject.audioMixerGroup;
    }

    public AudioClip GetRandomClip()
    {
        return Clips[Random.Range(0, Clips.Length)];
    }

    public void PlayRandom()
    {
        if (Clips.Length == 0)
            return;

        PlayClip(GetRandomClip(), PitchMin, PitchMax);
    }

    public void PlayClip(AudioClip clip, float pitchMin, float pitchMax)
    {
        soundObject.GetParameters();
        m_Source.pitch = soundObject.pitch;
        m_Source.volume = soundObject.volume;
        m_Source.spatialBlend = soundObject.spatialBlendVal;
        m_Source.PlayOneShot(clip);
    }
    
    public void PlayClip(AudioClip clip, SingleSoundSO so)
    {
        so.GetParameters();
        m_Source.pitch = so.pitch;
        m_Source.volume = so.volume;
        m_Source.spatialBlend = so.spatialBlendVal;
        m_Source.PlayOneShot(clip);
    }
}