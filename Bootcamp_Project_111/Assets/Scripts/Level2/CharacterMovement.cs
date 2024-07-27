using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;

    private Vector3 playerVelocity;
    private float verticalVelocity = 0;

    private bool isGrounded;
    public float rotateSpeed = .75f;
    public float runSpeed = 7.0f;
    private float gravityValue = 9.81f;

    public float jumpHeight = 20f;
    bool doubleJump = false;
    bool tripleJump = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GroundCheck();
        LookUp(); 
        Move();
        
        if(isGrounded && Input.GetKeyDown(KeyCode.Y))
        {
            Jump();
        }

        if(!isGrounded && verticalVelocity < 0f)
        {
            _animator.SetBool("IsFalling", true);
            Debug.Log("isfalling true");
        }
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

        if(playerSpeed > 0.3f)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        verticalVelocity -= gravityValue * Time.deltaTime;
        

        playerVelocity = horizontalVelocity;
        playerVelocity.y = verticalVelocity;


        _controller.Move(playerVelocity * Time.deltaTime);

        _animator.SetFloat("speed", playerSpeed);
    }

    void Jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
        _animator.SetBool("IsJumping", true);
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
            _animator.SetBool("IsGrounded", true);
            _animator.SetBool("IsFalling", false);
            _animator.SetBool("IsJumping", false);
            
            
        }
        else
        {
            isGrounded = false;
            _animator.SetBool("IsGrounded", false);
        }
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -5f;
        }
    }


    /*
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //play C
            _audioSource.PlayOneShot(SoundManager.Instance.sounds[1]);

            if (isGrounded)
            {
                Jump();
                doubleJump = true;
            }
            //jump(sonra I ve P ile triple jump.)
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            //play D
            _audioSource.PlayOneShot(SoundManager.Instance.sounds[2]);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //play E
            _audioSource.PlayOneShot(SoundManager.Instance.sounds[3]);

            if (!isGrounded && doubleJump)
            {
                //instantiate doesnt work sometimes?
                GameObject newPlatform = Instantiate(platforms[0], transform.position - Vector3.up, Quaternion.identity);
                Jump();
                StartCoroutine(DestroyPlatform(newPlatform));
                doubleJump = false;
                tripleJump = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            _audioSource.PlayOneShot(SoundManager.Instance.sounds[4]);
            //play F 
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _audioSource.PlayOneShot(SoundManager.Instance.sounds[5]);
            //play G 


            if (!isGrounded && tripleJump)
            {
                GameObject newPlatform = Instantiate(platforms[1], transform.position - Vector3.up, Quaternion.identity);
                Jump();
                StartCoroutine(DestroyPlatform(newPlatform));
                tripleJump = false;
            }
        }
    }
    */


}
