using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    public float volume = 0.5f;
    public float soundEffect = 0.5f;

    [SerializeField]
    public bool musicOn = true;
    [SerializeField]
    public bool sfxOn = true;

    // Singleton instance.
    public static SoundManager Instance = null;

    void Awake()
    {
        //If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlayMusic("BackgroundMusic");
    }

    public void PlaySFX(string name)
    {
        if (sfxOn)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Play();
        }
    }

    public void PlayMusic(string name)
    {
        if (musicOn)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void AdjustVolume(float volume)
    {

    }

    // Initialize the singleton instance.
    //private void Awake()
    //{
    //    // If there is not already an instance of SoundManager, set it to this.
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    //If an instance already exists, destroy whatever this object is to enforce the singleton.
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
    //    DontDestroyOnLoad(gameObject);
    //}

    // Play a single clip through the sound effects source.
    //public void Play(AudioClip clip)
    //{
    //    EffectsSource.clip = clip;
    //    EffectsSource.Play();
    //}

    // Play a single clip through the music source.
    //public void PlayMusic(AudioClip clip)
    //{
    //    MusicSource.clip = clip;
    //    MusicSource.Play();
    //}

    //public void PlayOrPauseMusic()
    //{
    //    if (soundsOn)
    //    {
    //        MusicSource.Pause();
    //        soundsOn = false;
    //    }
    //    else
    //    {
    //        MusicSource.Play();
    //        soundsOn = true;
    //    }
    //}

    //// Play a random clip from an array, and randomize the pitch slightly.
    //public void RandomSoundEffect(params AudioClip[] clips)
    //{
    //    int randomIndex = Random.Range(0, clips.Length);
    //    float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

    //    EffectsSource.pitch = randomPitch;
    //    EffectsSource.clip = clips[randomIndex];
    //    EffectsSource.Play();
    //}
}

