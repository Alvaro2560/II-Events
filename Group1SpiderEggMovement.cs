using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group1SpiderEggMovement : MonoBehaviour
{
    public Notificator notificator;
    public float speed = 1f;
    private bool isMoving = false;
    private GameObject targetEgg;

    void Start()
    {
        notificator.OnSpider1Collision += MoveToEgg;
    }

    void MoveToEgg()
    {
        isMoving = true;
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        float closestDistance = Mathf.Infinity;
        foreach (GameObject obj in allObjects)
        {
            if (obj.tag.StartsWith("huevo"))
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    targetEgg = obj;
                }
            }
        }
    }

    void Update()
    {
        if (isMoving && targetEgg != null)
        {
            float distance = Vector3.Distance(transform.position, targetEgg.transform.position);
            if (distance > 0.1f)
            {
                Vector3 direction = (targetEgg.transform.position - transform.position).normalized;
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