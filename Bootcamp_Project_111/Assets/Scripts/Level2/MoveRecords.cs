using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRecords : MonoBehaviour
{
    [SerializeField] GameObject[] records;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(audioSource.clip);

        foreach (var record in records)
        {
            record.gameObject.GetComponent<RecordRotation>().enabled = true;
            record.gameObject.GetComponent<DrumsSurface>().enabled = true;
        }
    }
}
