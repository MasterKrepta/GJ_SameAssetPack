using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{
    DetectTarget detect;
    Animator anim;
    public float speed, attackDelay;
    Transform player;
    Vector2 rotScale = new Vector2(0, 180);
    bool canAttack = true;
    public GameObject damageDealer;
    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponentInChildren<DetectTarget>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (detect.InRange && canAttack)
        {
            Attacking();
            StartCoroutine(ResetAttack());
        }
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //if (player.position.x <= transform.position.x)
        //{
        //    transform.rotation = Quaternion.Euler(Vector2.zero);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(rotScale);

        //}
        //transform.position -= transform.right * speed * Time.deltaTime;

    }

    private void Attacking()
    {
        anim.SetTrigger("attacking");
     
    }

    IEnumerator ResetAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public void DAMAGE_ON()
    {
        damageDealer.SetActive(true);
    }

    public void DAMAGE_OFF()
    {
        damageDealer.SetActive(false);
    }
}
