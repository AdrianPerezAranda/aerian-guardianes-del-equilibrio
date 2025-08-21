using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using System.Runtime.CompilerServices;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Animator animator;
    [SerializeField] TMPro.TextMeshProUGUI vida_Canva;
    [SerializeField] MusicController musicController;

    SpriteRenderer spriteRenderer;

    private int playerHealth;

    private void Start()
    {
        playerHealth = gameController.getPlayerHealth();

        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        if(transform.position.y <= -5.60)
        {
            SceneManager.LoadScene("LoseMenu");
            
            musicController.stopCurrentMusic();

        }


        if(transform.position.x >= 154)
        {
            Debug.Log("Boss");
            
            if (musicController.nivel_actual == 1)
            {
                SceneManager.LoadScene("Boss_1");

                musicController.stopCurrentMusic();

            }
            else if (musicController.nivel_actual == 3)
            {
                SceneManager.LoadScene("Boss_2");

                musicController.stopCurrentMusic();

            }
            else if (musicController.nivel_actual == 5)
            {
                SceneManager.LoadScene("Final_Boss");

                musicController.stopCurrentMusic();

            }

        }

        vida_Canva.text = "X" + playerHealth; 
    }


    public void LosseLifeAndHit(int losseLife)
    {
        playerHealth -= losseLife;
              

        StartCoroutine(damageColor(0.5f));
        

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
        if (playerHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("LoseMenu");

            musicController.stopCurrentMusic();

        }
    }

    public void restart()
    {
        gameObject.SetActive(false);
        playerHealth = gameController.getPlayerHealth();
    }

}
