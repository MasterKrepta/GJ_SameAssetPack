using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackTime = 0.5f;
    public float Distance;
    Animator anim;

    public GameObject attackPoint;
    Transform player;
    bool canAttack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(transform.position, player.position);
        if (Distance <= attackRange && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttak());

    }


    IEnumerator ResetAttak()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }
    void Attack_ON()
    {
        attackPoint.SetActive(true);
    }

    void Attack_OFF()
    {
        attackPoint.SetActive(false);
    }
}
