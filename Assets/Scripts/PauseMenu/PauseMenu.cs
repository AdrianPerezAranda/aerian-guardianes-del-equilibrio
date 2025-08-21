using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionAsset pauseMenuInput;
    [SerializeField] GameObject canvaPauseMenu;

    private InputAction pause;

    private float pauseMenuButtonValue;
    private void Start()
    {
        pauseMenuInput.Enable();


        pause = pauseMenuInput.FindActionMap("Pause").FindAction("Pause");


    }

    private void Update()
    {

        pauseMenuButtonValue = pause.ReadValue<float>();


        if (pauseMenuButtonValue != 0 && canvaPauseMenu.activeSelf == false)
        {
            canvaPauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }

}
