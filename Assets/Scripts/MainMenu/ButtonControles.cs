using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControles : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    public void menuControles()
    {
        musicController.stopCurrentMusic();

        SceneManager.LoadScene("Controles");

    }
}

