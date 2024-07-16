using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField]
    PlayableDirector playableDirector;
    //PlayableDirector playableDirectorStart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playableDirector.Play();
            //playableDirectorStart.Stop();
            StartCoroutine(CountdownNext());
        }
    }

    IEnumerator CountdownNext()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
