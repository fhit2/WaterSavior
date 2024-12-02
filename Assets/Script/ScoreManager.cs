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
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        UpdateScoreText(); 
    }

    public void AddScore()
{
    score += 10; 
    UpdateScoreText();
}

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    
}