using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Singleton
    public static MusicManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    AudioSource audioSource;
    public AudioClip overworldMusic;
    public AudioClip battleMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        if (audioSource.clip != newMusic)
        {
            audioSource.clip = newMusic;
            audioSource.Play();
        }
    }
}
