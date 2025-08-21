using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverButton : MonoBehaviour
{
    [SerializeField] GameObject menuAnterior;
    [SerializeField] GameObject menuActual;

    public void volver()
    {
        menuActual.SetActive(false);

        menuAnterior.SetActive(true);
    }
}
