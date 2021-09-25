using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsTracker : MonoBehaviour
{
    [Header("Character Attributes")]
    [Tooltip("Footsteps Sounds")]
    public SoundSO footstepsSO;

    [Tooltip("Hit Sounds")] public SoundSO hitSO;

    [Tooltip("Idle Sound")] public SingleSoundSO idleSO;
    [Tooltip("Jump Sound")] public SingleSoundSO jumpSO;
    [Tooltip("Land Sound")] public SingleSoundSO landSO;
}
