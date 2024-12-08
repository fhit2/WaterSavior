using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteUI;
    public int targetItems = 40;
    private int currentCollected = 0;

    public TextMeshProUGUI questProgressText;

    private bool questComplete = false;

    void Start()
    {
        UpdateQuestUI();
    }

    public void CollectItem()
    {
        if (!questComplete)
        {
            currentCollected++;
            UpdateQuestUI();

            if (currentCollected >= targetItems)
            {
                QuestCompleted();
            }
        }
    }

    void UpdateQuestUI()
    {
        questProgressText.text = $"{currentCollected} / {targetItems}";
    }

    void QuestCompleted()
    {
        questComplete = true;

    }

    public void CheckIfAllObjectsCollected()
    {
        if (FindObjectsOfType<DestroyOnClick>().Length <= 1)
        {
            levelCompleteUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        LevelTransition.Instance.MainMenu();
    }



}
