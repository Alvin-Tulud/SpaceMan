using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "FactoryRunAudioSO", menuName = "Create FactoryRunAudioSO")]

public class SFX : ScriptableObject
{
    public static void PlayOneShot(string path)
    {
        RuntimeManager.PlayOneShot(path);
    }
}
