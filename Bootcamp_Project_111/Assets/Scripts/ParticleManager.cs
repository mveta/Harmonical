using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject[] confettiEffect;
    public static ParticleManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (var c in confettiEffect)
        {
            c.SetActive(false);
        }
    }
}
