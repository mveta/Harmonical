using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;

    private Vector3 playerVelocity;
    private float verticalVelocity = 0;

    public float rotateSpeed = .75f;
    public float runSpeed = 7.0f;
    private float gravityValue = 9.81f;

    private float groundedTimer;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
 
        Move();
      
        LookUp();
    }

    void LookUp()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("lookUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("lookUp", false);
        }
    }

    private void Move()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float playerSpeed = runSpeed * Input.GetAxis("Vertical");

        Vector3 horizontalVelocity = forward * playerSpeed;
        verticalVelocity -= gravityValue * Time.deltaTime;

        playerVelocity = horizontalVelocity;
        playerVelocity.y = verticalVelocity;
        

        _controller.Move(playerVelocity * Time.deltaTime);

        _animator.SetFloat("speed", playerSpeed);
    }

  
}
