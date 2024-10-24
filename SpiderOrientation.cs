using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderOrientation : MonoBehaviour
{
    public Notificator notificator;
    public GameObject objective;
    private bool changeOrientation = false;

    void Start()
    {
        notificator.OnCylinderCollision += ChangeOrientation;
    }

    void ChangeOrientation()
    {
        changeOrientation = true;
    }

    void Update()
    {
        if (changeOrientation && objective != null)
        {
            transform.LookAt(objective.transform);
        }
    }
}