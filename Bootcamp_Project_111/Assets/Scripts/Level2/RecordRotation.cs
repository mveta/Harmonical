using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
 
    void Update()
    {
        transform.Rotate(0, 0, Time.smoothDeltaTime * rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
        Debug.Log(other.gameObject + " entered");
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);  
    }
}
