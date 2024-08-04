using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    GameObject canvas;
    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }
}
