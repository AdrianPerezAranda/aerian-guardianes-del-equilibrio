using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Controller_ : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    [SerializeField] TMPro.TextMeshProUGUI dialogo_luz;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_player;

    [SerializeField] GameObject contenedor_dialogo_luz;
    [SerializeField] GameObject contenedor_dialogo_player;

    [SerializeField] InputActionAsset pasar_dialogo;

    [SerializeField] GameObject guardiana_luz;
    [SerializeField] GameObject guardiana_luz_poseida;

    private string[] guardiana_luz_dialogos, protagonista_dialogos;

    private int intervenciones_guardiana_luz, intervenciones_protagonista, dialogos;

    private InputAction enter;

    private float cooldown, time;

    private void Start()
    {
        pasar_dialogo.Enable();

        enter = pasar_dialogo.FindActionMap("PasarDialogo").FindAction("Enter");

        guardiana_luz_dialogos = new string[]
        {
            "¡AAAAAAAAAAA!",
            "Si, gracias Aerian por salvarme de las manos de esa.",
            "Adelantate Aerian, yo voy a buscar ayuda al Reino de la Luz, cuidate."
        };

        protagonista_dialogos = new string[]
        {
            "¡SARITHA! ¿Estas bien?",
            "Tenemos que ir a por Dirak y a por las piedras.",
            "Vale, nos vemos Saritha."
        };

        intervenciones_guardiana_luz = intervenciones_protagonista = 0;

        dialogos = 1;

        time = 0.5f;

        cooldown = 0.5f;
    }

    private void Update()
    {
        if(enter.ReadValue<float>() != 0 && time >= cooldown)
        {
            if(dialogos == 1)
            {
                dialogoLuz();

                dialogos++;
            }
            else if(dialogos == 2)
            {
                guardiana_luz_poseida.SetActive(false);
                
                guardiana_luz.SetActive(true);

                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 3)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 4)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 5)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 6)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 7)
            {
                musicController.stopCurrentMusic();

                SceneManager.LoadScene("Level2");
            }

            time = 0;
        }
        else if (time < cooldown)
        {
            time += Time.deltaTime;
        }
    }

    private void dialogoLuz()
    {
        if (contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(false);
        }

        if (!contenedor_dialogo_luz.activeSelf)
        {
            contenedor_dialogo_luz.SetActive(true);
        }

        dialogo_luz.text = guardiana_luz_dialogos[intervenciones_guardiana_luz];

        intervenciones_guardiana_luz++;

    }

    private void dialogoPlayer()
    {
        if (contenedor_dialogo_luz.activeSelf)
        {
            contenedor_dialogo_luz.SetActive(false);
        }

        if (!contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(true);
        }

        dialogo_player.text = protagonista_dialogos[intervenciones_protagonista];

        intervenciones_protagonista++;

    }
}
