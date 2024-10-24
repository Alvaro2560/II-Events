using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;

public class Notificator : MonoBehaviour
{
    public delegate void Message();
    public event Message OnCylinderCollision;
    public event Message OnSpider1Collision;
    public event Message OnSpider2Collision;
    public event Message OnEgg1Collision;
    public event Message OnEgg2Collision;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "cilindro")
        {
            OnCylinderCollision();
        }
        else if (collider.gameObject.tag == "araña_grupo1")
        {
            OnSpider1Collision();
        }
        else if (collider.gameObject.tag == "araña_grupo2")
        {
            OnSpider2Collision();
        }
        else if (collider.gameObject.tag == "huevo_grupo1")
        {
            OnEgg1Collision();
        }
        else if (collider.gameObject.tag == "huevo_grupo2")
        {
            OnEgg2Collision();
        }
        collider.gameObject.SetActive(false);

    }
}