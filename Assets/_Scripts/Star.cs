using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    DetectTarget detect;
    Animator anim;
    public float speed;
    Transform player;
    Vector2 rotScale = new Vector2(0, 180);
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
        if (detect.InRange)
        {
            AttackPlayer();
        }
        else
        {
            anim.SetBool("attacking", false);
            Patrol();
        }
    }

    private void Patrol()
    {
        
    }

    private void AttackPlayer()
    {
        anim.SetBool("attacking", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (player.position.x <= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(Vector2.zero);
        }
        else
        {
            transform.rotation = Quaternion.Euler(rotScale);

        }
        transform.position -= transform.right * speed * Time.deltaTime;
    }
}
