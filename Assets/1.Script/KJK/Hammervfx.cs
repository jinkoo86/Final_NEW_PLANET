using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammervfx : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("닿았다");
    }
}
