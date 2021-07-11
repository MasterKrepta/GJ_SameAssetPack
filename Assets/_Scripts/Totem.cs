using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public Transform firePoint;

    public GameObject spike;
    bool canFire = true;
    public float FireRate = 2.5f;
    Transform player;
    DetectTarget detect;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        detect = GetComponent<DetectTarget>();
        //firePoint = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detect.InRange == true && canFire)
        {
            //int rand = Random.Range(0, firePoints.Length);
            Instantiate(spike, firePoint.position, Quaternion.identity);
            canFire = false;
            StartCoroutine(ResetFire());
        }
    }

    IEnumerator ResetFire()
    {
        yield return new WaitForSeconds(FireRate);
        canFire = true;
    }
}
