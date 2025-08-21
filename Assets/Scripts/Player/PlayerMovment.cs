using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] InputActionAsset movment;
    [SerializeField] InputActionAsset attacks;
    [SerializeField] GameController gameController;
    [SerializeField] PlayerAttackCaC playerAttackCaC;
    [SerializeField] SA_Attacks sa_Attacks;
    
    private bool limite;
    private int playerCaCDamage;
    private int playerAbilitiesDamage;
    private int jumpSpeed, playerSpeed;
    private InputAction horizontal, vertical, cac, sa_Light, sa_Darkness;
    private float fr, rg, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value, cooldownAttack, timeAttack;
    private Animator animator;
    private Rigidbody2D rb;
    public bool goRight;
    public SpriteRenderer spriteRenderer;
    private Vector2 inicialPos;
    private float cooldownSAAttack, timeSAAttack;


    [SerializeField] private FMODUnity.EventReference eventReference_ataqueCaC;

    private FMOD.Studio.EventInstance ataqueCaC;

    [SerializeField] private FMODUnity.EventReference eventReference_salto;

    private FMOD.Studio.EventInstance salto;

    [SerializeField] private FMODUnity.EventReference eventReference_ataque_Esp_Luz;

    private FMOD.Studio.EventInstance ataque_Esp_Luz;

    [SerializeField] private FMODUnity.EventReference eventReference_ataque_Esp_Osc;

    private FMOD.Studio.EventInstance ataque_Esp_Osc;
    private enum STATE
    {
        MOVMENT, IDLE, JUMP, ATTACK, DEATH, ATTACK_LIGHT, ATTACK_DARKNESS
    }
    STATE state;
    void Start()
    {
        ataqueCaC = RuntimeManager.CreateInstance(eventReference_ataqueCaC);
        salto = RuntimeManager.CreateInstance(eventReference_salto);
        ataque_Esp_Luz = RuntimeManager.CreateInstance(eventReference_ataque_Esp_Luz);
        ataque_Esp_Osc = RuntimeManager.CreateInstance(eventReference_ataque_Esp_Osc);

        state = STATE.IDLE;
        movment.Enable();
        attacks.Enable();
        animator = GetComponent<Animator>();
        horizontal = movment.FindActionMap("Movment").FindAction("Horizontal");
        vertical = movment.FindActionMap("Movment").FindAction("Vertical");
        cac = attacks.FindActionMap("CaC").FindAction("CaC");
        sa_Light = attacks.FindActionMap("SA").FindAction("Light");
        sa_Darkness = attacks.FindActionMap("SA").FindAction("Darkness");
        rb = GetComponent<Rigidbody2D>();

        cooldownSAAttack = gameController.getCooldownSAAttack();
        cooldownAttack = gameController.getCooldownAttack();
        playerCaCDamage = gameController.getPlayerCaCDamage();
        playerAbilitiesDamage = gameController.getPlayerAbilitiesDamage();
        jumpSpeed = gameController.getJumpSpeed();
        playerSpeed = gameController.getPlayerSpeed();

        timeAttack = cooldownAttack;

        timeSAAttack = cooldownSAAttack;

        inicialPos = transform.position;

        limite = false;

        
    }
 
    private void FixedUpdate()
    {
        if (CheckGround.isGrounded)
        {
            Debug.Log("Puede saltar");
        }
        else
        {
            Debug.Log("No puede saltar");
        }
        

        fr = vertical.ReadValue<float>();

        rg = horizontal.ReadValue<float>();

        attack_CaC_value = cac.ReadValue<float>();

        attack_sa_Light_value = sa_Light.ReadValue<float>();

        attack_sa_Darkness_value = sa_Darkness.ReadValue<float>();

        switch (state)
        {
            case STATE.IDLE:
                idleState(rg, fr, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                break;

            case STATE.MOVMENT:
                movmentState(rg, fr, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value);
                if (goRight)
                {
                    rb.velocity = new Vector2(rg * playerSpeed * Time.deltaTime, rb.velocity.y);
                    spriteRenderer.flipX = false;
                }
                else
                {
                    if (!limite){
                        rb.velocity = new Vector2(rg * playerSpeed * Time.deltaTime, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(2 * Time.deltaTime, rb.velocity.y);
                    }
    
                    spriteRenderer.flipX = true;
                }
                
                break;

            case STATE.JUMP:
                jumpState(rg, fr);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime);
                salto.start();
                break;

            case STATE.ATTACK:
                attackState(rg, fr, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value);
                ataqueCaC.start();
                break;

            case STATE.ATTACK_LIGHT:
                attackLightState(rg, fr, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value);
                ataque_Esp_Luz.start();
                sa_Attacks.sa_Light();
                break;

            case STATE.ATTACK_DARKNESS:
                attackDarknessState(rg, fr, attack_CaC_value, attack_sa_Light_value, attack_sa_Darkness_value);
                ataque_Esp_Osc.start();
                sa_Attacks.sa_Darkness();
                break;

        }

    }

    private void movmentState(float rg, float fr, float attack_CaC_value, float attack_sa_Light_value, float attack_sa_Darkness_value)
    {

        if (rg > 0)
        {
            animator.SetTrigger("WALK");
            goRight = true;
        }
        else if (rg < 0)
        {
            if (!limite)
            {
                animator.SetTrigger("WALK");
                goRight = false;
            }
            
        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }

        if (CheckGround.isGrounded == true && fr > 0)
        {
            animator.SetTrigger("JUMP");
            state = STATE.JUMP;
            

        }

        if(timeAttack >= cooldownAttack && attack_CaC_value != 0)
        {
            animator.SetTrigger("ATTACK");
            state = STATE.ATTACK;
            playerAttackCaC.Attack();

            timeAttack = 0;
        }
        else
        {
            if(timeAttack <= cooldownAttack)
            {
                timeAttack += Time.deltaTime;
            }
            
        }

        if (timeSAAttack >= cooldownSAAttack && attack_sa_Light_value != 0)
        {

            animator.SetTrigger("SA");
            state = STATE.ATTACK_LIGHT;

            timeSAAttack = 0;
        }
        else
        {
            if (timeSAAttack <= cooldownSAAttack)
            {
                timeSAAttack += Time.deltaTime;
            }

        }

        if (timeSAAttack >= cooldownSAAttack && attack_sa_Darkness_value != 0)
        {

            animator.SetTrigger("SA");
            state = STATE.ATTACK_DARKNESS;


            timeSAAttack = 0;
        }
        else
        {
            if (timeSAAttack <= cooldownSAAttack)
            {
                timeSAAttack += Time.deltaTime;
            }

        }

    }

        private void idleState(float rg, float fr, float attack_CaC_value, float attack_sa_Light_value, float attack_sa_Darkness_value)
    {
        if (rg != 0)
        {
            animator.SetTrigger("WALK");
            state = STATE.MOVMENT;
        }
        else if (fr > 0 && CheckGround.isGrounded == true)
        {
            animator.SetTrigger("JUMP");
            state = STATE.JUMP;
            
        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }

        if (timeAttack >= cooldownAttack && attack_CaC_value != 0)
        {
                animator.SetTrigger("ATTACK");
                state = STATE.ATTACK;
                playerAttackCaC.Attack();

           timeAttack = 0;
        }
        else
        {
            if (timeAttack <= cooldownAttack)
            {
                timeAttack += Time.deltaTime;
            }

        }

        if (timeSAAttack >= cooldownSAAttack && attack_sa_Light_value != 0)
        {
            animator.SetTrigger("SA");
            state = STATE.ATTACK_LIGHT;


            timeSAAttack = 0;
        }
        else
        {
            if (timeSAAttack <= cooldownSAAttack)
            {
                timeSAAttack += Time.deltaTime;
            }

        }

        if (timeSAAttack >= cooldownSAAttack && attack_sa_Darkness_value != 0)
        {
            animator.SetTrigger("SA");
            state = STATE.ATTACK_DARKNESS;


            timeSAAttack = 0;
        }
        else
        {
            if (timeSAAttack <= cooldownSAAttack)
            {
                timeSAAttack += Time.deltaTime;
            }

        }
    }
    
    private void jumpState(float rg, float fr)
    {
        if (fr > 0 && CheckGround.isGrounded == true)
        {
            animator.SetTrigger("JUMP");
        }
        else if(rg != 0 && CheckGround.isGrounded == true)
        {
            state = STATE.MOVMENT;
        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }
    }

    private void attackState(float rg, float fr, float attack_CaC_value, float attack_sa_Light_value, float attack_sa_Darkness_value)
    {
        if (rg != 0)
        {

            animator.SetTrigger("WALK");
            state = STATE.MOVMENT;
        }
        else if (fr > 0 && CheckGround.isGrounded == true)
        {
            animator.SetTrigger("JUMP");
            state = STATE.JUMP;
         
        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }

    }

    private void attackLightState(float rg, float fr, float attack_CaC_value, float attack_sa_Light_value, float attack_sa_Darkness_value)
    {
        if (rg != 0)
        {

            animator.SetTrigger("WALK");
            state = STATE.MOVMENT;
        }
        else if (fr > 0 && CheckGround.isGrounded == true)
        {
            animator.SetTrigger("JUMP");
            state = STATE.JUMP;

        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }

    }

    private void attackDarknessState(float rg, float fr, float attack_CaC_value, float attack_sa_Light_value, float attack_sa_Darkness_value)
    {
        if (rg != 0)
        {

            animator.SetTrigger("WALK");
            state = STATE.MOVMENT;
        }
        else if (fr > 0 && CheckGround.isGrounded == true)
        {
            animator.SetTrigger("JUMP");
            state = STATE.JUMP;

        }
        else
        {
            animator.SetTrigger("IDLE");
            state = STATE.IDLE;
        }

    }

    public void LimiteMapa(bool estarEnElLimite)
    {
        limite = estarEnElLimite;
    }
}
