using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyMovement : MonoBehaviour
{
    public enum State
    {
        PATROL, MOVING, ATTACKING
    }
    Transform Player;
    Vector2 patrolOrigin;
    [SerializeField] State currentState = State.PATROL;
    public DetectTarget detect;

    public float Speed;
    public float moveDistance = 2;

    public float Distance;
    bool movingRight = false;
    bool toggleCheck = true;
    
    Vector2 rotScale = new Vector2(0, 180);

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>().transform;
        patrolOrigin = GetOrigin();
        currentState = State.PATROL;
    }

    // Update is called once per frame
    void Update()
    {
        DetectionCheck();
        if (currentState == State.PATROL)
        {
            
            Patrol();
        }
        else
        {
            Moving();
        }
    }

    private void DetectionCheck()
    {
        if (detect.InRange && currentState == State.PATROL)
        {
            currentState = State.MOVING;
            
        }

        else if (!detect.InRange && currentState == State.MOVING)
        {
            patrolOrigin = GetOrigin();
            currentState = State.PATROL;

        }
    }

    private void Moving()
    {
        //todo moving script
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        if (Player.position.x <= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(Vector2.zero);
        }
        else
        {
            transform.rotation = Quaternion.Euler(rotScale);

        }
    }

    private void Patrol()
    {
        Distance = Vector2.Distance(patrolOrigin, transform.position);

        if (!movingRight )
        {
            if (Distance > moveDistance && toggleCheck)
            {
                transform.rotation = Quaternion.Euler(rotScale);
                movingRight = true;
                StartCoroutine(ToggleDirection());
            }
        }
        else
        {
            if (Distance > moveDistance && toggleCheck)
            {
                transform.rotation = Quaternion.Euler(Vector2.zero);
                movingRight = false;
                StartCoroutine(ToggleDirection());
            }
        }
        

        //if (Distance <= moveDistance && movingRight)
        //{
        //    transform.rotation = Quaternion.Euler(Vector2.zero);
        //    movingRight = false;
        //}

        transform.position -= transform.right * Speed * Time.deltaTime;
    }

    Vector3 GetOrigin()
    {
        return transform.position;
    }

    IEnumerator ToggleDirection()
    {
        toggleCheck = false;
        yield return new WaitForSeconds(0.25f);
        toggleCheck = true;
    }
}
