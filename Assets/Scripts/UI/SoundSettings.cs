using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>().value = SoundManager.Instance.musicVolume;
        gameObject.transform.GetChild(4).gameObject.GetComponent<Slider>().value = SoundManager.Instance.sfxVolume;
        //AdjustSFX(SoundManager.Instance.sfxVolume);
        //AdjustVolume(SoundManager.Instance.musicVolume);
    }

    public void StopMusic()
    {
        SoundManager.Instance.currentMusicSource.volume = 0f;
    }

    public void StopSFX()
    {
        SoundManager.Instance.currentEffectsSource.volume = 0f;
    }

    public void AdjustVolume(float volume)
    {
        SoundManager.Instance.AdjustVolume(volume/10);
    }

    public void AdjustSFX(float volume)
    {
        SoundManager.Instance.AdjustSFX(volume/10);
    }



}
