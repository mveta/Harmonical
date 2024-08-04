using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannonBall : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody ballRigidbody;

    public float ballSpeed;
    public KeyCode rightNote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rightNote))
        {
            GameObject cannonBall = Instantiate(ball, transform.position, transform.rotation);
            ballRigidbody = cannonBall.GetComponent<Rigidbody>();
            ballRigidbody.velocity = new Vector3(0, 0, ballSpeed);
        }
    }
    
}
