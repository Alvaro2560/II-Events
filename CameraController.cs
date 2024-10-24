using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("cubo").transform;    
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
