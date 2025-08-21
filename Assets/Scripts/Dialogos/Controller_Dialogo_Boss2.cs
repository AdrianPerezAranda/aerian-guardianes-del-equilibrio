using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Controller_Dialogo_Boss2 : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    [SerializeField] TMPro.TextMeshProUGUI dialogo_oscuridad;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_player;

    [SerializeField] GameObject contenedor_dialogo_oscuridad;
    [SerializeField] GameObject contenedor_dialogo_player;

    [SerializeField] InputActionAsset pasar_dialogo;

    [SerializeField] GameObject guardiana_oscuridad;
    [SerializeField] GameObject guardiana_oscuridad_poseida;

    private string[] guardiana_oscuridad_dialogos, protagonista_dialogos;

    private int intervenciones_guardiana_oscuridad, intervenciones_protagonista, dialogos;

    private InputAction enter;

    private float cooldown, time;

    private void Start()
    {
        pasar_dialogo.Enable();

        enter = pasar_dialogo.FindActionMap("PasarDialogo").FindAction("Enter");

        guardiana_oscuridad_dialogos = new string[]
        {
            "¡AAAAAAAAAAA!",
            "Si.",
            "Nunca me has caido bien, pero gracias.",
            "Perfecto, yo voy a buscar ayuda al Reino de la Oscuridad."
        };

        protagonista_dialogos = new string[]
        {
            "¡DIRAK! ¿Estas bien?",
            "¿Ya esta? ¿Ni un gracias, ni nada? Borde.",
            "Voy a por las piedras."
        };

        intervenciones_guardiana_oscuridad = intervenciones_protagonista = 0;

        dialogos = 1;

        time = 0.5f;

        cooldown = 0.5f;
    }

    private void Update()
    {
        if (enter.ReadValue<float>() != 0 && time >= cooldown)
        {
            if (dialogos == 1)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 2)
            {
                guardiana_oscuridad_poseida.SetActive(false);

                guardiana_oscuridad.SetActive(true);

                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 3)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 4)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 5)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 6)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 7)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 8)
            {
                musicController.stopCurrentMusic();;

                SceneManager.LoadScene("Level3");
            }

            time = 0;
        }
        else if (time < cooldown)
        {
            time += Time.deltaTime;
        }
    }

    private void dialogoOscuridad()
    {
        if (contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(false);
        }

        if (!contenedor_dialogo_oscuridad.activeSelf)
        {
            contenedor_dialogo_oscuridad.SetActive(true);
        }

        dialogo_oscuridad.text = guardiana_oscuridad_dialogos[intervenciones_guardiana_oscuridad];

        intervenciones_guardiana_oscuridad++;

    }

    private void dialogoPlayer()
    {
        if (contenedor_dialogo_oscuridad.activeSelf)
        {
            contenedor_dialogo_oscuridad.SetActive(false);
        }

        if (!contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(true);
        }

        dialogo_player.text = protagonista_dialogos[intervenciones_protagonista];

        intervenciones_protagonista++;

    }
}
