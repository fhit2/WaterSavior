using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale == 0f) // Cek apakah game sedang dijeda
        {
            if (audioSource.isPlaying)
                audioSource.Pause(); // Hentikan audio jika sedang berjalan
        }
        else
        {
            if (!audioSource.isPlaying)
                audioSource.UnPause(); // Lanjutkan audio jika sedang dihentikan
        }
    }
}
