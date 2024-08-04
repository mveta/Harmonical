using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsActivate : MonoBehaviour
{
    [SerializeField] Animator[] animators;
    [SerializeField] GameObject canvas;

    [SerializeField] GameObject[] musicNotes;

    GameManager gameManager;
    private bool inside = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.Y))
        {
            animators[2].enabled = true;

            if (animators[0].enabled && animators[1].enabled &&
            animators[2].enabled && animators[3].enabled &&
            animators[4].enabled)
            {
                StartCoroutine(ShowCanvas());
                musicNotes[0].SetActive(true);
                musicNotes[1].SetActive(true);
                inside = false;

            }
        }
        if (inside && Input.GetKeyDown(KeyCode.I))
        {
            animators[3].enabled = true;

            if (animators[0].enabled && animators[1].enabled &&
            animators[2].enabled && animators[3].enabled &&
            animators[4].enabled)
            {
                StartCoroutine(ShowCanvas());
                musicNotes[0].SetActive(true);
                musicNotes[1].SetActive(true);
                inside = false;

            }
        }
        if (inside && Input.GetKeyDown(KeyCode.P))
        {
            animators[4].enabled = true;

            if (animators[0].enabled && animators[1].enabled &&
            animators[2].enabled && animators[3].enabled &&
            animators[4].enabled)
            {
                StartCoroutine(ShowCanvas());
                musicNotes[0].SetActive(true);
                musicNotes[1].SetActive(true);
                inside = false;
            }
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        animators[0].enabled = true;
        animators[1].enabled = true;
        inside = true;
        gameManager.jumpable = false;
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
        gameManager.jumpable = true;
    }

    IEnumerator ShowCanvas()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        canvas.SetActive(false);
    }
}
