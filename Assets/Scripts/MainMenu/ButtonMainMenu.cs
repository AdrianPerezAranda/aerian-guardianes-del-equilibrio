using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class ButtonMainMenu : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    public void startGame()
    {
        SceneManager.LoadScene("StartHistory");

        musicController.stopCurrentMusic();


    }
}
