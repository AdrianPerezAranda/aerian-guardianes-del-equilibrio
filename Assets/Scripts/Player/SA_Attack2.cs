using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Attack2 : MonoBehaviour
{
    
    [SerializeField] PlayerMovment playerMovment;

    [SerializeField] GameController gameController;

    [SerializeField] GameObject attack_Light_Prefab;
    [SerializeField] GameObject attack_Darkness_Prefab;

    [SerializeField] Attack_Move attack_Light_Move;
    [SerializeField] Attack_Move attack_Darkness_Move;


    GameObject attack_Light, attack_Darkness;

    public void sa_Light()
    {
        attack_Light = Instantiate(attack_Light_Prefab, transform.position , Quaternion.identity);
   

        if (playerMovment.goRight)
        {
            
            attack_Light.GetComponent<Rigidbody2D>().velocity = (transform.right * 10);

        }
        else
        {
            attack_Light.GetComponent<SpriteRenderer>().flipX = true;
            attack_Light.GetComponent<Rigidbody2D>().velocity = -(transform.right * 10);

        }
        
    }

    public void sa_Darkness()
    {
        attack_Darkness = Instantiate(attack_Darkness_Prefab, transform.position, Quaternion.identity);


        if (playerMovment.goRight)
        {

            attack_Darkness.GetComponent<Rigidbody2D>().velocity = (transform.right * 10);

        }
        else
        {
            attack_Darkness.GetComponent<SpriteRenderer>().flipX = true;
            attack_Darkness.GetComponent<Rigidbody2D>().velocity = -(transform.right * 10);

        }
    }
}
