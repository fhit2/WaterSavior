using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // Singleton instance
    private int score = 0; // Variabel untuk menyimpan skor

    [SerializeField] private TextMeshProUGUI scoreText; // Referensi ke teks skor

    private void Awake()
    {
        // Jika sudah ada instance, hancurkan yang baru
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        UpdateScoreText(); // Perbarui teks skor saat permainan dimulai
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}