﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General_Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
