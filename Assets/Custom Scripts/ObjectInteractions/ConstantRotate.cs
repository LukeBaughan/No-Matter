﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 15.0f;
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, _rotationSpeed) * Time.deltaTime * -1, Space.World);
    }
}
