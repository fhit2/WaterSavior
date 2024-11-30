using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText; // Untuk menampilkan waktu
    [SerializeField]
    float remainingTime; // Waktu yang tersisa
    [SerializeField]
    GameObject gameOverPanel; // Panel Game Over

    void Start()
    {
        // Pastikan panel Game Over tidak aktif di awal
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0 && !gameOverPanel.activeSelf)
        {
            remainingTime = 0;
            timerText.color = Color.red;

            // Aktifkan panel Game Over
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            // Opsional: Hentikan waktu atau aksi lainnya
            Time.timeScale = 0f;
        }

        // Hitung menit dan detik dari waktu yang tersisa
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Perbarui teks timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
