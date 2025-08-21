using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameController gameController;

    private int lifes;


    private void Start()
    {
        lifes = gameController.getEnemyHealth();

    }

    public void LosseLifeAndHit(int losseLife)
    {
        lifes -= losseLife;

        Debug.Log("Vida enemigo: " + lifes);

        if(lifes > 0)
        {
            StartCoroutine(damageColor(0.5f));
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
        if(lifes <= 0)
        {
            gameObject.SetActive(false);

        }
    }

}
