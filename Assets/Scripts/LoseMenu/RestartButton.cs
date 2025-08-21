using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] MusicController musicController;
    public void restart()
    {
        SceneManager.LoadScene("Level1");

        musicController.stopCurrentMusic();
    }
}
