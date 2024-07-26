using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "Create SoundsSO")]

public class Sounds : ScriptableObject
{
    public static void PlayOneShot(string path)
    {
        RuntimeManager.PlayOneShot(path);
    }

    public static FMOD.Studio.EventInstance musicRef;

    public static void StartMusic(string path)
    {
        musicRef = RuntimeManager.CreateInstance(path);
        musicRef.start();
    }

    public static void StopMusic()
    {
        musicRef.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
