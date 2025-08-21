using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameController gameController;

    public float[] moveSpots;
    private float enemyWaitTime;
    private float enemyStartWaitTime;
    private int enemySpeed;
    private int i = 0;
    private Animator animator;
    private Vector2 actualPos;
    private bool canAttak;
    private Vector2 inicialPos;
    public bool goRight;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyStartWaitTime = gameController.getEnemyStartWaitTime();
        enemySpeed = gameController.getEnemySpeed();


        enemyWaitTime = enemyStartWaitTime;

        inicialPos = transform.position;
    }

    
    void Update()
    {

        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(moveSpots[i], transform.position.y), enemySpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, new Vector2(moveSpots[i], transform.position.y)) < 0.1f)
        {
            if (enemyWaitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }



                enemyWaitTime = enemyStartWaitTime;


            }
            else
            {
                enemyWaitTime -= Time.deltaTime;


            }


        }

        if (i != 0)
        {
            spriteRenderer.flipX = true;
            goRight = false;
        }
        else
        {
            spriteRenderer.flipX = false;
            goRight = true;
        }
        

    }

    

    IEnumerator CheckEnemyMoving()
    {

        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (actualPos.x != transform.position.x)
        {
            walkAnimation();
        }
        else
        {
            idleAnimation();
        }
       
    }

    private void walkAnimation()
    {
        animator.SetTrigger("WALK");
    }

    private void idleAnimation()
    {
        animator.SetTrigger("IDLE");
    }

    public void restart()
    {
        transform.position = inicialPos;
        i = 0;

        enemyStartWaitTime = gameController.getEnemyStartWaitTime();
        enemySpeed = gameController.getEnemySpeed();


        enemyWaitTime = enemyStartWaitTime;

    }
}
