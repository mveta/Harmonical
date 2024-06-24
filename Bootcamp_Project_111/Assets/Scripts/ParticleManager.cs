using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject[] particleEffects;
    public static ParticleManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
