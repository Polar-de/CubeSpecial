using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeBackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public void SetLevel(float sliderValue)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }
}
