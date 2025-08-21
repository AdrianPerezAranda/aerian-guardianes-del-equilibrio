using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVolver : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    public void volver()
    {
        musicController.stopCurrentMusic();

        SceneManager.LoadScene("MainMenu");


    }
}

