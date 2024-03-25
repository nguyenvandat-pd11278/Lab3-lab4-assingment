using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class pinwheelController : MonoBehaviour
{
    public float rotationSpeed = 100f; 
   
    void Start()
    {
        
    }
    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime
            );
        transform.rotation = transform.rotation * deltaRotation;
    }
}
