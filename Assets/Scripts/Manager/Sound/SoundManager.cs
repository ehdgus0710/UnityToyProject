using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Sington<SoundManager>
{
    public AudioMixer m_Audio;

    private void Start()
    {
        //m_Audio.SetFloat("masterVol", Mathf.Log10(1) * 20);
    }
}
