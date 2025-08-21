using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [SerializeField] LifePlayer lifePlayer;

    private int enemyDamage;
    private void Start()
    {
        enemyDamage = gameController.getEnemyDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifePlayer.LosseLifeAndHit(enemyDamage);
        }
        
    }
}
