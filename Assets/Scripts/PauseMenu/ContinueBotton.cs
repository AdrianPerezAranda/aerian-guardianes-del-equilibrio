using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueBotton : MonoBehaviour
{

    [SerializeField] GameObject canvaPauseMenu;


    public void continuar()
    {
        canvaPauseMenu.SetActive(false);

        Time.timeScale = 1;
    }
}
