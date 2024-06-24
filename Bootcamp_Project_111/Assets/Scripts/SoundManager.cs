using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public List<AudioClip> sounds = new List<AudioClip>();
    public List<AudioClip> runner = new List<AudioClip>();

    public AudioSource myRun;
    public float Timer = 5f;

    public void Awake()
    {
        Instance = this;
    }

    public void SoundPlay(int i)
    {
        GetComponent<AudioSource>().clip = sounds[i];
        GetComponent<AudioSource>().Play();
    }

    public void SoundPlayOneShot()
    {
        if (Timer <= 0)
        {
            int n = Random.Range(1, runner.Count);
            myRun.clip = runner[n];
            myRun.PlayOneShot(myRun.clip);
            // move picked sound to index 0 so it's not picked next time
            runner[n] = runner[0];
            runner[0] = myRun.clip;


            Timer = 0.6f;

        }
    }
}
