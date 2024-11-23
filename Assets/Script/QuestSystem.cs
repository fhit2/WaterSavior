using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSystem : MonoBehaviour
{
<<<<<<< HEAD
    public int targetItems = 40;
=======
    public int targetItems = 10;
>>>>>>> 17943a0f9a85a203b192ad6db4644cb8f83e8b5c
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
<<<<<<< HEAD
        questProgressText.text = $"{currentCollected} / {targetItems}";
=======
        questProgressText.text = $"Collect Trash: {currentCollected} / {targetItems}";
>>>>>>> 17943a0f9a85a203b192ad6db4644cb8f83e8b5c
    }

    void QuestCompleted()
    {
        questComplete = true;

    }
}
