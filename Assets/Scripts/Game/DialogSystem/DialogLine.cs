using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class DialogLine
{
    public string text;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
}
