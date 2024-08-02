using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectKey : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] KeyCode key;
    

    GameObject canvas;
    GameObject note;
    GameObject particle;

    AudioSource audioSource;
    private void Start()
    {
        gameManager = GameManager.Instance;
        canvas = transform.GetChild(0).gameObject;
        particle = transform.GetChild(1).gameObject;
        note = transform.GetChild(2).gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
   
        audioSource.PlayOneShot(audioSource.clip);
        note.SetActive(false);
        particle.SetActive(true);
        StartCoroutine(ShowCanvas());

        switch (key)
        {
            case KeyCode.P:
                gameManager.keyActive_p = true;
                break;
            case KeyCode.O:
                gameManager.keyActive_o = true;
                break;
            case KeyCode.U:
                gameManager.keyActive_u = true;
                break;
            case KeyCode.Y:
                gameManager.keyActive_y = true;
                gameManager.jumpable = true;
                break;
            default:
                break;
        }

    }

    IEnumerator ShowCanvas()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
    }
}
