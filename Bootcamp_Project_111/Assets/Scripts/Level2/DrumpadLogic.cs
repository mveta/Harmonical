using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumpadLogic : MonoBehaviour
{

    int index;
    

    void Start()
    {
        index = transform.GetSiblingIndex();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = index + 1; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).gameObject.SetActive(false);
        }


        if (transform.parent.childCount == index + 1)
        {
            Debug.Log("You did it!");
        }
        else
        {
            transform.parent.GetChild(index + 1).gameObject.SetActive(true);
        }
    }
}
