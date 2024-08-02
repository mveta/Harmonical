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
    [SerializeField] float rotateSpeed = .75f;
    [SerializeField] float runSpeed = 7.0f;
    [SerializeField] float gravityValue = 9.81f;

    public float jumpHeight = 20f;
    public bool bootspeedglobal;
    bool boatspeed = false;
    bool doubleJump = false;
    bool tripleJump = false;
    bool onRecord = false;
    Transform record;

    [SerializeField] GameObject[] platforms;
    [SerializeField] GameObject barrier,musiccasebarrier;

    GameManager _gameManager;
    SoundManager _soundManager;

    AudioSource _audioSource;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = transform.GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _gameManager = GameManager.Instance;
        _soundManager = SoundManager.Instance;
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
        bootspeedglobal = boatspeed;
        Debug.Log("character : "+boatspeed);      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MusicalNote"))
        {
            Destroy(other.gameObject);
            barrier.transform.Rotate(0, 0, 90f);
            barrier.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.CompareTag("HandDrum"))
        {
            Destroy(other.gameObject);
           musiccasebarrier.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Y) && _gameManager.keyActive_y)
        {
            //play C
            _audioSource.PlayOneShot(_soundManager.sounds[1]);

            if (isGrounded && _gameManager.jumpable)
            {
                Jump();
                doubleJump = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.U) && _gameManager.keyActive_u)
        {
            //play D
            _audioSource.PlayOneShot(_soundManager.sounds[2]);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //play E
            _audioSource.PlayOneShot(_soundManager.sounds[3]);

            if (!isGrounded && doubleJump && _gameManager.keyActive_p)
            {
                platforms[0].SetActive(true);
                platforms[0].transform.parent = null;
     
                Jump();

                StartCoroutine(ResetPlatform(platforms[0]));

                doubleJump = false;
                tripleJump = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.O) && _gameManager.keyActive_o)
        {
            //Play F
            _audioSource.PlayOneShot(_soundManager.sounds[4]);
             
        }
        if (Input.GetKeyDown(KeyCode.P) && _gameManager.keyActive_p)
        {
            //play G
            _audioSource.PlayOneShot(_soundManager.sounds[5]);
             
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
