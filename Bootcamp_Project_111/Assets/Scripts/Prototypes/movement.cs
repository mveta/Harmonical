using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 3f;
    void Update()
    {
        transform.position = transform.position + (Vector3.forward * Time.deltaTime * speed);

    }
}
