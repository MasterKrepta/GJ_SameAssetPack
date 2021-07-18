using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Door teleport;
    public bool canTeleport = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canTeleport)
            {
                teleport.ToggleTeleport();
  
                collision.gameObject.transform.position = teleport.transform.position;
            }

        }
    }


    public void ToggleTeleport()
    {
        teleport.canTeleport = false;
        StartCoroutine(ResetTeleport());
    }

    IEnumerator ResetTeleport()
    {
        yield return new WaitForSeconds(10);
        canTeleport = true;
    }
}


    

    
