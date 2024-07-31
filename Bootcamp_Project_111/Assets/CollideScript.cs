using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    BoatMovement boatMovement;

    private void Start()
    {
        boatMovement = new BoatMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            boatMovement.transspeed = 0f;
            Debug.Log("durdu");
        }
    }
}
