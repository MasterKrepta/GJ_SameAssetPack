using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float JumpForce = 100f;
    SpriteRenderer sr;
    bool jump = false;
    CharacterController cc;
    Vector2 input;
    bool facingRight = true;
    Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        cc = GetComponent<CharacterController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

        if (input.x < 0 && facingRight)
        {
            
            Flip(true);
        }

        if (input.x > 0 && !facingRight)
        {
            
            Flip(false);
        }

            cc.Move(input * Time.fixedDeltaTime);

        
    }

    void Flip(bool value)
    {
        facingRight = !facingRight;
        scale.x *= -1;
        transform.localScale = scale;
        
        
    }
}
