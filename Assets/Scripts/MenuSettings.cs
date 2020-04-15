using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer _audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetSoundEffect(float volume)
    {
        _audioMixer.SetFloat("EffectVolume", volume);
    }
}
