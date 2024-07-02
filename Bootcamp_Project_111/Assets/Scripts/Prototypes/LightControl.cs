using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public KeyCode rightNote;
    public GameObject discoBall;
    public float rotationSpeed;

    private void Update()
    {
        if (Input.GetKey(rightNote))
        {
            gameObject.transform.RotateAround(discoBall.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
