using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    /// <summary>
    /// Function loads the main menu scene (scene 0 of build settings).
    /// It is called when the user tries to leave the Options or Credits scene.
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Function is called when the use selects the start button.
    /// Currently loads the Bin Test Scene, currently set as scene 1, but should be changed to the game scene later.
    /// </summary>
    public void MenuStart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Function loads the options scene, currently set as scene 2.
    /// </summary>
    public void MenuOptions()
    {
        SceneManager.LoadScene(2);
    }
    
    /// <summary>
    /// Function loads the credits scene, currently set as scene 3.
    /// </summary>
    public void MenuCredits()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Function closes the game application.
    /// May be changed later to have an exit game scene before closing the game.
    /// </summary>
    public void MenuExit()
    {
        // Quit out of built applications
        Application.Quit();
        // Quit out of Unity Editor
        // UnityEditor.EditorApplication.isPlaying = false;
    }


}
