using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group2Movement : MonoBehaviour
{
    public Notificator notificator;
    public GameObject cylinder;
    public float speed = 0.3f;
    private bool isMoving = false;

    void Start()
    {
        cylinder = GameObject.FindGameObjectWithTag("cilindro");
        notificator.OnCylinderCollision += MoveToCylinder;
    }

    void MoveToCylinder()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving && cylinder != null)
        {
            Vector3 direction = (cylinder.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}