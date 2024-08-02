using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool keyActive_y;
    public bool keyActive_u;
    
    public bool keyActive_o;
    public bool keyActive_p;
    public bool jumpable;
    [SerializeField] RawImage imageY;
    [SerializeField] RawImage imageU;
    [SerializeField] RawImage imageO;
    [SerializeField] RawImage imageP;
    private void Awake()
    {
        Instance = this;
        
        keyActive_y = false;
        keyActive_u = false;

        keyActive_o = false;
        keyActive_p = false;
        jumpable = false;
    }

    private void Update()
    {
        if (keyActive_y)
        {
            imageY.color = Color.white;
        }
        if (keyActive_u) 
        {
            imageU.color = Color.white;
        }
        if (keyActive_o) 
        {
            imageO.color = Color.white;
        }
        if (keyActive_p)
        {
            imageP.color = Color.white;
        }
        
    }
}
