using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group1Movement : MonoBehaviour
{
    public Notificator notificator;
    public GameObject objectiveSphere;
    public float speed = 1f;
    private bool isMoving = false;

    void Start()
    {
        objectiveSphere = GameObject.FindGameObjectWithTag("esfera-tipo2");
        notificator.OnCylinderCollision += MoveToSphere;
    }

    void MoveToSphere()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving && objectiveSphere != null)
        {
            Vector3 direction = (objectiveSphere.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}