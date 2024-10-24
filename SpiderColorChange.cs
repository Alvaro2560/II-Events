using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class SpiderColorChange : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer spiderRenderer;
    [SerializeField]
    private Material material;
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "huevo_grupo2")
        {
            spiderRenderer.material = material;
        }
    } 
}