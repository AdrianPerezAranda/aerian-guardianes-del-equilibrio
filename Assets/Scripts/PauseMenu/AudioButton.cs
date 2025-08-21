using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject menuAudio;

    public void controles()
    {
        menuPrincipal.SetActive(false);

        menuAudio.SetActive(true);
    }
}
