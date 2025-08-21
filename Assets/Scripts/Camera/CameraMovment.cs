using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovment : MonoBehaviour
{

    [SerializeField] InputActionAsset movment;

    [SerializeField] GameController gameController;

    private InputAction horizontal;

    private Rigidbody2D rb2D;

    private int cameraSpeed;

    private float rg;

    private void Start()
    {
        horizontal = movment.FindActionMap("Movment").FindAction("Horizontal");

        rb2D = GetComponent<Rigidbody2D>();

        cameraSpeed = gameController.getPlayerSpeed();
    }

    private void FixedUpdate()
    {
        rg = horizontal.ReadValue<float>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (rg > 0)
            {
                rb2D.velocity = new Vector2(rg * cameraSpeed * Time.deltaTime, rb2D.velocity.y);
            }

            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);

        }
            
    }
}
