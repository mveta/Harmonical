using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumpadStart : MonoBehaviour
{
    int index;


    void Start()
    {
        index = transform.GetSiblingIndex();
    }

    private void OnTriggerEnter(Collider other)
    {
        //sound

        transform.parent.GetChild(index+1).gameObject.SetActive(true);

        for (int i = index + 2; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).gameObject.SetActive(false);
        }

    }
}
