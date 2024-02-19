using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InMenuAnyButton : MonoBehaviour
{
    // Start is called before the first frame update
    MenuFunctions menuFunctions;
    PlayerInput playerInput;
    InputAction exitBackToMenu;
    void Start()
    {
        // get action of any button pressed
        menuFunctions = GetComponent<MenuFunctions>();
        playerInput = GetComponent<PlayerInput>();
        exitBackToMenu = playerInput.actions["ExitBackToMenu"];
        exitBackToMenu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // check if button is pressed
        if(exitBackToMenu.IsPressed())
        {
            menuFunctions.ReturnToMenu();
            Debug.Log("Back to menu");
        }
    }
}
