using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCaC : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] GameObject attackFather;
    [SerializeField] GameController gameController;

    private BoxCollider2D boxCollider2D;
    private bool goRight;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        goRight = playerMovment.goRight;

    }
    public void Attack()
    {
        if (!goRight)
        {
            attackFather.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            attackFather.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        boxCollider2D.enabled = true;

        Invoke("NoHit", 0.3f);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            

            collision.gameObject.GetComponent<EnemyDamage>().LosseLifeAndHit(gameController.getPlayerCaCDamage());



            boxCollider2D.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {

            collision.gameObject.GetComponent<Boss_Damage>().LosseLifeAndHit(gameController.getPlayerCaCDamage());



            boxCollider2D.enabled = false;
        }
    }

    private void NoHit()
    {
        boxCollider2D.enabled = false;
    }
}
