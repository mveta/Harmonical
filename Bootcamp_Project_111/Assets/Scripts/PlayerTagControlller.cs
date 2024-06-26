using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagControlller : MonoBehaviour
{ 
    public PuzzleManager puzzleManager;
    public string triggerSequence;// Her kapý için farklý triggerSequence

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            puzzleManager.ActivatePuzzle(triggerSequence);
            Debug.Log("Puzzle Activated with sequence: " + triggerSequence);
        }
    }
}

