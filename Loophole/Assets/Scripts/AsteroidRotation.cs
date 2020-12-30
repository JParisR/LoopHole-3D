﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    float speed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}