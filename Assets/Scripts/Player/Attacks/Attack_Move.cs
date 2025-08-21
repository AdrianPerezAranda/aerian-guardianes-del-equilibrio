using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Move : MonoBehaviour
{

    [SerializeField] GameController gameController;
    private float timeLife, timeAlive = 50;

    private int damage;

    private void Start()
    {

        damage = gameController.getPlayerAbilitiesDamage();
    }
    void Update()
    {

        timeLife += Time.deltaTime;

        if (timeAlive - timeLife <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyDamage>().LosseLifeAndHit(damage);

        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss_Damage>().LosseLifeAndHit(damage);

        }
        
    }
}
