using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void MenuStart()
    {
        // opens Bin Scene
        // TODO: Replace with game scene
        SceneManager.LoadScene(1);
    }

    public void MenuOptions()
    {
        // load options scene, or activate options menu
        SceneManager.LoadScene(2);
    }
    
    public void MenuCredits()
    {
        // load Credits scene
        SceneManager.LoadScene(3);
    }
    public void MenuExit()
    {
        Application.Quit();
    }


}
