using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTeleport : MonoBehaviour
{
    public Notificator notificator;
    public GameObject objective;

    void Start()
    {
        notificator.OnCylinderCollision += MoveToCapsule;
    }

    void MoveToCapsule()
    {
        if (objective != null)
        {
            transform.position = objective.transform.position;
        }
    }
}