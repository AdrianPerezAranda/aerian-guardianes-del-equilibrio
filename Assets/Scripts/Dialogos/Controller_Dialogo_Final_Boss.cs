using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Controller_Dialogo_Final_Boss : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    [SerializeField] TMPro.TextMeshProUGUI dialogo_villana;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_player;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_guardiana_luz;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_guardian_oscuridad;

    [SerializeField] GameObject contenedor_dialogo_villana;
    [SerializeField] GameObject contenedor_dialogo_player;
    [SerializeField] GameObject contenedor_dialogo_guardiana_luz;
    [SerializeField] GameObject contenedor_dialogo_guardian_oscuridad;

    [SerializeField] InputActionAsset pasar_dialogo;

    [SerializeField] GameObject guardiana_luz;
    [SerializeField] GameObject guardian_oscuridad;

    private string[] villana_dialogos, protagonista_dialogos, guardiana_luz_dialogos, guardian_oscuridad_dialogos;

    private int intervenciones_villana, intervenciones_protagonista, dialogos;

    private InputAction enter;

    private float cooldown, time;

    
    private void Start()
    {
        pasar_dialogo.Enable();

        enter = pasar_dialogo.FindActionMap("PasarDialogo").FindAction("Enter");

        villana_dialogos = new string[]
        {
            "¡NOO, NO VALE, HAY QUE ACABAR CON ELLOS!",
            "¡No tu no lo entiendes!",
            "¡No hay otra opcion! no nos dejaron otra opcion…",
            "¡Pero…!",
            "Esta bien…",
            "Hasta siempre Aerian."
        };

        protagonista_dialogos = new string[]
        {
            "Ya vale Nylux.",
            "Entiendo que estés enfadada con ambos reinos por desterrarte.",
            "¡Pero esta no es la solución!",
            "Si hay otras opciones, podemos demostrarles que somos utiles para ambos reinos.",
            "Nylux, dejalo ya, por favor."
        };

        guardiana_luz_dialogos = new string[]
        {
            "Nylux queda detenida por el Reino de la Luz."
        };

        guardian_oscuridad_dialogos = new string[]
        {
            "Nylux queda detenida por el Reino de la Oscuridad."
        };

        intervenciones_villana = intervenciones_protagonista = 0;

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
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 2)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 3)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 4)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 5)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 6)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 7)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 8)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 9)
            {
                dialogoPlayer();

                dialogos++;
            }
            else if (dialogos == 10)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 11)
            {
                guardian_oscuridad.SetActive(true);

                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 12)
            {
                guardiana_luz.SetActive(true);

                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 13)
            {
                dialogoVillana();

                dialogos++;
            }
            else if (dialogos == 14)
            {
                musicController.stopCurrentMusic();


                SceneManager.LoadScene("WinMenu");
            }

            time = 0;
        }
        else if (time < cooldown)
        {
            time += Time.deltaTime;
        }
    }

    private void dialogoVillana()
    {
        if (contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(false);
        }
        else if (contenedor_dialogo_guardiana_luz.activeSelf)
        {
            contenedor_dialogo_guardiana_luz.SetActive(false);
        }
        else if (contenedor_dialogo_guardian_oscuridad.activeSelf)
        {
            contenedor_dialogo_guardian_oscuridad.SetActive(false);
        }

        if (!contenedor_dialogo_villana.activeSelf)
        {
            contenedor_dialogo_villana.SetActive(true);
        }

        dialogo_villana.text = villana_dialogos[intervenciones_villana];

        intervenciones_villana++;

    }

    private void dialogoPlayer()
    {
        if (contenedor_dialogo_villana.activeSelf)
        {
            contenedor_dialogo_villana.SetActive(false);
        }
        else if (contenedor_dialogo_guardiana_luz.activeSelf)
        {
            contenedor_dialogo_guardiana_luz.SetActive(false);
        }
        else if (contenedor_dialogo_guardian_oscuridad.activeSelf)
        {
            contenedor_dialogo_guardian_oscuridad.SetActive(false);
        }

        if (!contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(true);
        }

        dialogo_player.text = protagonista_dialogos[intervenciones_protagonista];

        intervenciones_protagonista++;

    }

    private void dialogoLuz()
    {
        if (contenedor_dialogo_villana.activeSelf)
        {
            contenedor_dialogo_villana.SetActive(false);
        }
        else if (contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(false);
        }
        else if (contenedor_dialogo_guardian_oscuridad.activeSelf)
        {
            contenedor_dialogo_guardian_oscuridad.SetActive(false);
        }

        if (!contenedor_dialogo_guardiana_luz.activeSelf)
        {
            contenedor_dialogo_guardiana_luz.SetActive(true);
        }

        dialogo_guardiana_luz.text = guardiana_luz_dialogos[0];


    }

    private void dialogoOscuridad()
    {
        if (contenedor_dialogo_villana.activeSelf)
        {
            contenedor_dialogo_villana.SetActive(false);
        }
        else if (contenedor_dialogo_player.activeSelf)
        {
            contenedor_dialogo_player.SetActive(false);
        }
        else if (contenedor_dialogo_guardiana_luz.activeSelf)
        {
            contenedor_dialogo_guardiana_luz.SetActive(false);
        }

        if (!contenedor_dialogo_guardian_oscuridad.activeSelf)
        {
            contenedor_dialogo_guardian_oscuridad.SetActive(true);
        }

        dialogo_guardian_oscuridad.text = guardian_oscuridad_dialogos[0];

    }
}
