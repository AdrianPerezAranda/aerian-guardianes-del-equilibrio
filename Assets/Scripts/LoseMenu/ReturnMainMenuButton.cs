using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenuButton : MonoBehaviour
{

    [SerializeField] MusicController musicController;


    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        musicController.stopCurrentMusic();

    }
}
