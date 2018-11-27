// File: SceneChanger
// Description: Has button functions to change scenes

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string currentScene;
    bool isAtStorefront = true;
    public Button back;
    public Button hideShow;

    // Change from currentScene to scene
    public void changeScene(string scene)
    {
        // Disable hide/show button
        //hideShow.gameObject.SetActive(false);

        // Enable back button
        back.gameObject.SetActive(true);

        // Load scene on top of storefront if there isn't already aother scene open
        if (isAtStorefront)
        {
            isAtStorefront = false;
            currentScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
        // Or close the current scene and load the new scene
        // (if the scene selected is not already open)
        else if (!scene.Equals(currentScene))
        {
            SceneManager.UnloadSceneAsync(currentScene);
            currentScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    // Return focus to storefront scene
    public void backToStorefront()
    {
        isAtStorefront = true; // reset boolean to true

        SceneManager.UnloadSceneAsync(currentScene); // unload currentScene
        
        //hideShow.gameObject.SetActive(true); // re-activate hide/show button

        back.gameObject.SetActive(false); // de-activate backToStorefront button
    }
}
