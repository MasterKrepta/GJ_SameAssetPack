using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [SerializeField] float smoothSpeed = .1f;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        Vector3 dir = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, dir, smoothSpeed);
        transform.position = smoothPos;
    }
}