using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerTagControlller : MonoBehaviour
{ 
    public PuzzleManager puzzleManager;
    public string triggerSequence;// Her kapý için farklý triggerSequence
    public string doorName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            puzzleManager.ActivatePuzzle(triggerSequence);
            puzzleManager.sceneName = doorName;
            puzzleManager.isJumpActive = false;
            Debug.Log("Puzzle Activated with sequence: " + triggerSequence);
        }
    }
}

