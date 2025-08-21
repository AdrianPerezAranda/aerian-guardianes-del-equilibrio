using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalButton : MonoBehaviour
{
    [SerializeField] MusicController musicController;
    public void mainMenu()
    {

        SceneManager.LoadScene("MainMenu");

        musicController.stopCurrentMusic();

    }
}
