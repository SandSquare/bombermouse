using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{

    [SerializeField]
    GameObject volumeSlider;

    [SerializeField]
    GameObject sfxSlider;

    private void Start()
    {
        volumeSlider.GetComponent<Slider>().value = SoundManager.Instance.musicVolume*10;
        sfxSlider.GetComponent<Slider>().value = SoundManager.Instance.sfxVolume*10;
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

    public void PlayClickSound()
    {
        SoundManager.Instance.PlaySFX("Click2");
    }



}
