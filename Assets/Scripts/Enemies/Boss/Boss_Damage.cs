using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Damage : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameController gameController;
    [SerializeField] MusicController musicController;

    [Header ("Barra de vida")]
    [SerializeField] GameObject vida100;
    [SerializeField] GameObject vida75;
    [SerializeField] GameObject vida50;
    [SerializeField] GameObject vida25;
    [SerializeField] GameObject vida0;

    private int lifes, inicialLifes;


    private void Start()
    {
        lifes = gameController.getBossHealth();

        inicialLifes = lifes;
    }

    public void LosseLifeAndHit(int losseLife)
    {
        lifes -= losseLife;

        if (lifes > 0)
        {
            StartCoroutine(damageColor(0.5f));
        }

        if(lifes <= 15 && lifes >= 11)
        {
            vida100.SetActive(false);

            vida75.SetActive(true);
        }
        else if(lifes <= 10 && lifes >= 6)
        {
            vida75.SetActive(false);

            vida50.SetActive(true);
        }
        else if (lifes <= 5 && lifes >= 1)
        {
            vida50.SetActive(false);

            vida25.SetActive(true);
        }
        else if (lifes <= 0)
        {
            vida25.SetActive(false);

            vida0.SetActive(true);
        }

        CheckLife();
    }

    IEnumerator damageColor(float seconds)
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(seconds);

        spriteRenderer.color = Color.white;
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            gameObject.SetActive(false);
            
            if (musicController.nivel_actual == 2)
            {
                SceneManager.LoadScene("Win_First_Boss");

                musicController.stopCurrentMusic();
            }
            else if (musicController.nivel_actual == 4)
            {

                SceneManager.LoadScene("Win_Second_Boss");

                musicController.stopCurrentMusic();
            }
            else if (musicController.nivel_actual == 6)
            {

                SceneManager.LoadScene("Win_Final_Boss");

                musicController.stopCurrentMusic();
            }

            

        }
    }
}
