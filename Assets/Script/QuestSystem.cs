using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSystem : MonoBehaviour
{
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
}
