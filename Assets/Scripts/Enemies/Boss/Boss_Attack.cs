using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [SerializeField] GameController gameController;

    private int attackDamage;

    public Vector3 attackOffset;
    public float attackRange = 0.5f;
    public LayerMask attackMask;

    private void Start()
    {
        attackDamage = gameController.getBossDamage();
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        

        if (colInfo.gameObject.CompareTag("Player"))
        {
            Debug.Log("colInfo no es Null: " + colInfo + " Daño de ataque: " + attackDamage);

            colInfo.GetComponent<LifePlayer>().LosseLifeAndHit(attackDamage);
        }
        else
        {
            Debug.Log("colInfo es Null: " + colInfo);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
