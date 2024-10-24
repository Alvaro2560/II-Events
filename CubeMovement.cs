using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 7.5f;
    public Vector3 direction;
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalAxis, 0, verticalAxis).normalized * speed * Time.deltaTime);
    }
}
