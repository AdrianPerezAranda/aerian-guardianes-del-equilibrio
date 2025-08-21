using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    /*
    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] EnemyDamage enemyDAmage;
    [SerializeField] LifePlayer lifePlayer;
    [SerializeField] AIBasic aiBasic;*/

    public static GameController instance = null;

    public int playerHealth;
    public int playerCaCDamage;
    public int playerAbilitiesDamage;
    public int playerSpeed;
    public int jumpSpeed;
    public float cooldownAttack;
    public float cooldownSAAttack;
    public int enemySpeed;
    public int enemyDamage;
    public int enemyHealth;
    public int enemyStartWaitTime;
    public int bossHealth;
    public int bossDamage;
    public float cooldownAttackEnemy;
    public float sa_Attaks_Speed;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public int getPlayerCaCDamage()
    {
        return playerCaCDamage;
    }
    public int getPlayerAbilitiesDamage()
    {

        return playerAbilitiesDamage;     
    }

    public int getPlayerSpeed()
    {
        return playerSpeed;
    }

    public int getJumpSpeed()
    {
        return jumpSpeed;
    }

    public float getCooldownAttack()
    {
        return cooldownAttack;
    }    

    public float getCooldownSAAttack()
    {
        return cooldownSAAttack;
    }

    public int getEnemySpeed()
    {

        return enemySpeed;

    }
    public int getEnemyHealth()
    {
        return enemyHealth;
    }

    public int getEnemyDamage()
    {
        return enemyDamage;
    }

    public int getEnemyStartWaitTime()
    {
        return enemyStartWaitTime;
    }
    

    public int getBossHealth()
    {
        return bossHealth;
    }

    public int getBossDamage()
    {
        return bossDamage;
    }

    public float getCooldownAttackEnemy()
    {
        return cooldownAttackEnemy;
    }
    
    public float getSa_Attaks_Speed()
    {

        return sa_Attaks_Speed;  
    }

    /*
    public void restart()
    {
        playerMovment.restart();
        enemyDAmage.restart();
        lifePlayer.restart();
        aiBasic.restart();
    }*/
}
