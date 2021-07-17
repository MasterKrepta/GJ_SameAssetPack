using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    Quaternion iniRot;
    // Start is called before the first frame update

    private void Start()
    {
        iniRot = transform.rotation;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = iniRot;
    }
}
