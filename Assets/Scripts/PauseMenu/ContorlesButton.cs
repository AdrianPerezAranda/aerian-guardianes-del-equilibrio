using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContorlesButton : MonoBehaviour
{
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject menuControles;

    public void controles()
    {
        menuPrincipal.SetActive(false);

        menuControles.SetActive(true);
    }
}
