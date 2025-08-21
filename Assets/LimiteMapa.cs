using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteMapa : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovment.LimiteMapa(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovment.LimiteMapa(false);
        }
    }
}
