using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieOnAnimationEnd : MonoBehaviour
{
    public void ON_ANIMATIONEND()
    {
        Destroy(gameObject);
    }
}
