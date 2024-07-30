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
    bool onRecord = false;
    Transform record;

    [SerializeField] GameObject[] platforms;

    GameManager _gameManager;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = transform.GetComponentInChildren<Animator>();
        _gameManager = GameManager.Instance;
    }

    void Update()
    {
        GroundCheck();
        LookUp(); 
        Move();

        Inputs();

        if(!isGrounded && verticalVelocity < 0f)
        {
            _animator.SetBool("IsFalling", true);

            if (onRecord)
            {
                transform.parent = null;
                onRecord = false;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed = 15f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            runSpeed = 7f;
        }

                

        if(onRecord && record != null)
        {
            transform.parent = record.transform;
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

        if (onRecord)
        {
            transform.parent = null;
            onRecord = false;
        }

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


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Record"))
        {
            onRecord = true;
            record = hit.transform;
        }
    }
    
    
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Y)) // && _gameManager.keyActive_y
        {
            //play C
            //_audioSource.PlayOneShot(SoundManager.Instance.sounds[1]);

            if (isGrounded)
            {
                Jump();
                doubleJump = true;
            }
            //jump(sonra I ve P ile triple jump.)
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Play D");
            //_audioSource.PlayOneShot(SoundManager.Instance.sounds[2]);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //play E
            //_audioSource.PlayOneShot(SoundManager.Instance.sounds[3]);

            if (!isGrounded && doubleJump)
            {
                platforms[0].SetActive(true);
                platforms[0].transform.parent = null;
     
                Jump();

                StartCoroutine(ResetPlatform(platforms[0]));

                doubleJump = false;
                tripleJump = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Play F");
            //_audioSource.PlayOneShot(SoundManager.Instance.sounds[4]);
             
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //_audioSource.PlayOneShot(SoundManager.Instance.sounds[5]);
            //play G 


            if (!isGrounded && tripleJump)
            {
                platforms[1].SetActive(true);
                platforms[1].transform.parent = null;

                Jump();

                StartCoroutine(ResetPlatform(platforms[1]));
                tripleJump = false;
            }
        }

    }

    IEnumerator ResetPlatform(GameObject obj)
    {
        yield return new WaitForSeconds(1f);

        obj.SetActive(false);
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
    }

}
