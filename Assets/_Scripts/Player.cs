using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float jumpForce = 500, speed = 2f, throwForce = 200f, rechargeTime = 2f;
    
    Vector3 movement;
    bool facingRight = true;
    Vector2 scale;

    Rigidbody2D rb;
    public Transform knife, throwPoint;

    Knife knifeScript;
    public bool CanThrow = true;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        knifeScript = FindObjectOfType<Knife>();
        scale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }
 
    private Vector3 GetInput()
    {

        return new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
    void Update()
    {
        movement = GetInput();
        if (movement.x != 0)
            anim.SetBool("Moving", true);
        else
            anim.SetBool("Moving", false);

        if (movement.x < 0 && facingRight)
        {

            Flip(true);
        }

        if (movement.x > 0 && !facingRight)
        {

            Flip(false);
        }


        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.G) && knife != null)
        {
            knife = null;
            knifeScript.ThrowKnife();
        }

    }
    //public void EquipKnife(Transform knife)
    //{
    //    knife.position = throwPoint.transform.position;
    //    knife.parent = throwPoint.transform;
    //}

    void Flip(bool value)
    {
        facingRight = !facingRight;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
