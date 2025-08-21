using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Contoller_Dialogo_Principal : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    [SerializeField] TMPro.TextMeshProUGUI dialogo_luz;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_oscuridad;
    [SerializeField] TMPro.TextMeshProUGUI dialogo_luz_oscuridad;
    [SerializeField] TMPro.TextMeshProUGUI nombre_luz_oscuridad;

    [SerializeField] GameObject contenedor_dialogo_luz;
    [SerializeField] GameObject contenedor_dialogo_oscuridad;
    [SerializeField] GameObject contenedor_dialogo_luz_oscuridad;

    [SerializeField] InputActionAsset pasar_dialogo;

    [SerializeField] GameObject villano;
    [SerializeField] GameObject guardiana_luz;
    [SerializeField] GameObject guardian_oscuridad;
    [SerializeField] GameObject guardianes_poseidos;

    private string[] guardiana_luz_dialogos, guardian_oscuridad_dialogos, ambos_guardianes_dialogos, protagonista_dialogos, villana_dialogos;

    private int intervenciones_guardiana_luz, intervenciones_guardian_oscuridad, intervenciones_ambos_guardianes, intervenciones_protagonista, intervenciones_villana, dialogos;

    private InputAction enter;

    private float cooldown, time;

void Start()
    {
        pasar_dialogo.Enable();

        enter = pasar_dialogo.FindActionMap("PasarDialogo").FindAction("Enter");

        guardiana_luz_dialogos = new string[] 
        {
            "AERIAN! ¡Necesitamos tu ayuda!",
            "¿Pero TU?",
            "No eres un simple soldado.",
            "Sabemos todo lo que pasa en este reino, Aerian.",
            "Porque vimos potencial en ti, y sabemos que esto podria pasar algun dia.",
            "Aerian, calla.",
            "Efectivamente Aerian, son los desterrados de ambos reinos.",
            "No vamos a ir contigo",
            "¿Que es esto?, ¿Dirak tu tambien sientes esto?"
        };

        guardian_oscuridad_dialogos = new string[]
        {
            "Acaban de robar las piedras del equilibrio.",
            "Queremos que nos ayudes a recuperarlas…",
            "Sabemos tu secreto.",
            "¿Entonces, que dices?",
            "¡QUE TE CALLES! Ella es…",
            "Recuperaremo…",
            "Por supuesto que no quien te cre…",
            "Si pero no se qu…",
        };

        ambos_guardianes_dialogos = new string[]
        {
            "¿Que?",
            "¡AAAAAAAAAAAA!",
            "Sí señora."

        };

        protagonista_dialogos = new string[]
        {
            "¿Pero como es posible, si estabais defendiendolas? Sois unos inutiles.",
            "Bueno y ¿que quereis que yo haga?",
            "¿Pero como quereis que os ayude soy un simple soldado?",
            "¿¡QUE, CO-COMO L-LO SA-SABEIS!?",
            "¿Entonces por qué no me habéis desterrado como a los demas?",
            "Por supuesto que acepto, per…",
            "¿A que son inutiles? Ya se lo he dicho yo.",
            "Que si, que perdon y e…",
            "¡ESPERA! Has dicho Clan Sombra.",
            "Esos no son…",
            "¡SARITHA, DIRAK!, ¿E-estais bien?",
            "¿Que les has hecho?",

        };

        villana_dialogos = new string[]
        {
            "Pero y ¿esta reunion de inutiles?",
            "Permiteme presentarme, soy Nylux, jefa del grandioso Clan Sombra.",
            "El grandioso Clan Sombra.",
            "Bla, bla, bla, lo que tu digas, vosotros dos venir conmigo.",
            "¿Sois sordos o algo?",
            "¿A si que no quereis venir…?",
            "Estan mas que bien.",
            "¿Yo? Nada, solo que no me hacian caso, en fin vamos.",

        };

        intervenciones_guardiana_luz = intervenciones_guardian_oscuridad = intervenciones_ambos_guardianes = intervenciones_protagonista = intervenciones_villana = 0;

        dialogos = 1;

        time = 0.5f;

        cooldown = 0.5f;
    }

    void Update()
    {

        if(dialogos == 1)
        {
            dialogoLuz();

            dialogos++;
        }
        

        if (enter.ReadValue<float>() != 0 && time >= cooldown)
        {
            if (dialogos == 2)
            {
                dialogoOscuridad();

                dialogos++;

            }
            else if (dialogos == 3)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 4)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 5)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 6)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 7)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 8)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 9)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 10)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 11)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 12)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 13)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 14)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 15)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 16)
            {
                dialogoLuzOscuridad(2);

                villano.SetActive(true);

                guardiana_luz.GetComponent<SpriteRenderer>().flipX = false;

                guardian_oscuridad.GetComponent<SpriteRenderer>().flipX = false;

                dialogos++;
            }
            else if (dialogos == 17)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 18)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 19)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 20)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 21)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 22)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 23)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 24)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 25)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 26)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 27)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 28)
            {
                dialogoLuzOscuridad(3);

                dialogos++;
            }
            else if (dialogos == 29)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 30)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 31)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 32)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 33)
            {
                dialogoLuz();

                dialogos++;
            }
            else if (dialogos == 34)
            {
                dialogoOscuridad();

                dialogos++;
            }
            else if (dialogos == 35)
            {
                dialogoLuzOscuridad(3);

                guardiana_luz.SetActive(false);
                guardian_oscuridad.SetActive(false);

                guardianes_poseidos.SetActive(true);

                dialogos++;
            }
            else if (dialogos == 36)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 37)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 38)
            {
                dialogoLuzOscuridad(1);

                dialogos++;
            }
            else if (dialogos == 39)
            {
                dialogoLuzOscuridad(2);

                dialogos++;
            }
            else if (dialogos == 40)
            {
                dialogoLuzOscuridad(3);

                dialogos++;
            }
            else if(dialogos == 41)
            {
                musicController.stopCurrentMusic();

                SceneManager.LoadScene("Level1");
            }

            time = 0;
        }
        else if(time < cooldown) 
        {
                time += Time.deltaTime;
        }
    }

    private void dialogoLuzOscuridad(int habla)
    {
        if (contenedor_dialogo_luz.activeSelf)
        {
            contenedor_dialogo_luz.SetActive(false);
        }
        else if (contenedor_dialogo_oscuridad.activeSelf)
        {
            contenedor_dialogo_oscuridad.SetActive(false);
        }

        if (!contenedor_dialogo_luz_oscuridad.activeSelf)
        {
            contenedor_dialogo_luz_oscuridad.SetActive(true);
        }

        if (habla == 1)
        {
            nombre_luz_oscuridad.text = "AERIAN";

            dialogo_luz_oscuridad.text = protagonista_dialogos[intervenciones_protagonista];

            intervenciones_protagonista++;
        }
        else if (habla == 2)
        {
            nombre_luz_oscuridad.text = "NYLUX";

            dialogo_luz_oscuridad.text = villana_dialogos[intervenciones_villana];

            intervenciones_villana++;
        }
        else if (habla == 3)
        {
            nombre_luz_oscuridad.text = "SARITHA Y DIRAK";

            dialogo_luz_oscuridad.text = ambos_guardianes_dialogos[intervenciones_ambos_guardianes];

            intervenciones_ambos_guardianes++;
        }

    }


    private void dialogoLuz()
    {
        if (contenedor_dialogo_oscuridad.activeSelf)
        {
            contenedor_dialogo_oscuridad.SetActive(false);
        }
        else if (contenedor_dialogo_luz_oscuridad.activeSelf)
        {
            contenedor_dialogo_luz_oscuridad.SetActive(false);
        }


        if (!contenedor_dialogo_luz.activeSelf)
        {
            contenedor_dialogo_luz.SetActive(true);
        }

        dialogo_luz.text = guardiana_luz_dialogos[intervenciones_guardiana_luz];

        intervenciones_guardiana_luz++;

    }

    private void dialogoOscuridad()
    {
        if (contenedor_dialogo_luz.activeSelf)
        {
            contenedor_dialogo_luz.SetActive(false);
        }
        else if (contenedor_dialogo_luz_oscuridad.activeSelf)
        {
            contenedor_dialogo_luz_oscuridad.SetActive(false);
        }


        if (!contenedor_dialogo_oscuridad.activeSelf)
        {
            contenedor_dialogo_oscuridad.SetActive(true);
        }

        dialogo_oscuridad.text = guardian_oscuridad_dialogos[intervenciones_guardian_oscuridad];

        intervenciones_guardian_oscuridad++;

    }
}
