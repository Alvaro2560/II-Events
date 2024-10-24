using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group1SpiderMovement : MonoBehaviour
{
    public Notificator notificator;
    public GameObject objective;
    public float speed = 1f;
    private bool isMoving = false;

    void Start()
    {
        notificator.OnSpider2Collision += MoveToSphere;
    }

    void MoveToSphere()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving && objective != null)
        {
            float distance = Vector3.Distance(transform.position, objective.transform.position);
            if (distance > 0.1f)
            {
                Vector3 direction = (objective.transform.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}