using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For managing scenes
using UnityEngine.UI;             // For Button components

public class NextButton : MonoBehaviour
{
    public Button nextButton; // Reference to the Next button
    public string mapObjectName = "Map"; // The name of the GameObject to find in the MainMenu scene

    void Start()
    {
        // Add the listener for when the Next button is clicked
        nextButton.onClick.AddListener(LoadMapFromMainMenu);
    }

    void LoadMapFromMainMenu()
    {
        // Load the MainMenu scene additively to fetch the map
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);

        // Use a coroutine to wait for the scene to load
        StartCoroutine(FindAndLoadMap());
    }

    private System.Collections.IEnumerator FindAndLoadMap()
    {
        // Wait until the scene has fully loaded
        yield return null;

        // Find the map GameObject in the MainMenu scene
        GameObject map = GameObject.Find(mapObjectName);

        if (map != null)
        {
            // Do something with the map, e.g., instantiate it in GameplayScene
            Instantiate(map, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Map object not found in MainMenu scene!");
        }

        // Unload the MainMenu scene to clean up
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
