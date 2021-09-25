using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SpatialBlendType { Blend3D, Blend2D };

[CreateAssetMenu(menuName = "Audio Events/Custom SO")]
public class SoundSO : ScriptableObject
{
    public static string nowPlaying;
    private int clipIndex = 0;
    public AudioClip[] myAudioClips;
    public AudioMixerGroup audioMixerGroup;
    
    public SpatialBlendType spatialBlend;
    [MinMaxRange(0.2f, 1f)] public RangedFloat Volume;
    [MinMaxRange(0.2f, 3f)] public RangedFloat Pitch;

    [HideInInspector]
    public float volume, pitch,spatialBlendVal;

    public void GetParameters()
    {
        volume = Random.Range(Volume.minValue, Volume.maxValue);
        pitch = Random.Range(Pitch.minValue, Pitch.maxValue);
        CheckSpatialBlend();
    }

    public void SetDefaultParameters()
    {
        volume = 0.8f;
        pitch = 1.0f;
    }
    
    public void Play(AudioSource source)
    {
        if (source)
        {
            if (myAudioClips.Length == 0) return;
            if (audioMixerGroup)
                source.outputAudioMixerGroup = audioMixerGroup;

            CheckSpatialBlend(source);
            PlaySequential(source);
            source.Play();
            
        }
    }
    private void CheckSpatialBlend(AudioSource source)
    {
        if(source)
            source.spatialBlend = spatialBlend == SpatialBlendType.Blend2D ? 0 : 1;
    }
    private void CheckSpatialBlend()
    {
        spatialBlendVal = spatialBlend == SpatialBlendType.Blend2D ? 0 : 1;
    }
    
    private void PlaySequential(AudioSource source)
    {
        if (source)
        {
            if (clipIndex == myAudioClips.Length)
            {
                clipIndex = 0;
            }

            source.clip = myAudioClips[clipIndex];
            clipIndex++;
            nowPlaying = source.clip.name;
            source.volume = Random.Range(Volume.minValue, Volume.maxValue);
            source.pitch = Random.Range(Pitch.minValue, Pitch.maxValue);
        }
    }
}
