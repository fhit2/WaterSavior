using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueHolder1 : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }
        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate1();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            LevelTransition.Instance.Map();
            AudioManager.Instance.SceneMusic(2);

        }

        private void Deactivate1()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

