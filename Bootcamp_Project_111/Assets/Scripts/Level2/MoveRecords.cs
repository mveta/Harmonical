using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRecords : MonoBehaviour
{
    [SerializeField] GameObject[] records;
 
    private void OnTriggerEnter(Collider other)
    {
        foreach (var record in records)
        {
            record.gameObject.GetComponent<RecordRotation>().enabled = true;
            record.gameObject.GetComponent<DrumsSurface>().enabled = true;
        }
    }
}
