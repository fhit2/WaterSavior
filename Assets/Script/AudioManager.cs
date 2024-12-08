using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource, musicSource, moveAudioSource;

    [SerializeField] private AudioClip shove;
    [SerializeField] private AudioClip move;

    [Header("Scene Music")]
    [SerializeField] private AudioClip[] sceneMusic;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAudioSource = gameObject.AddComponent<AudioSource>();
        moveAudioSource.loop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneMusic(0);
    }

    public void Shove()
    {
        audioSource.clip = shove;
        audioSource.Play();
    }

    public void Move()
    {
        if (!moveAudioSource.isPlaying) 
        {
            moveAudioSource.clip = move;
            moveAudioSource.Play();
        }
    }

    public void StopMove()
    {
        if (moveAudioSource.isPlaying)
        {
            moveAudioSource.Stop();
        }
    }


    public void SceneMusic(int sceneNumber)
    {
        musicSource.clip = sceneMusic[sceneNumber];
        musicSource.Play();
    }
}
