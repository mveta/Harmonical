using UnityEngine;
using System;
using DG.Tweening;
using System.Collections;
namespace MarwanZaky
{
    public class PlayerMovement : Character
    {
        public enum MoveAir { Moveable, NotMoveable }

        public static Action<int> OnCurrentControllerChange;
        public static Action OnAttack;

        const float GRAVITY = -9.81f;
        const bool DEBUG = true;

        Collider col;
        Transform cam;

        Vector3 velocity = Vector3.zero;

        int currentController = 0;

        bool isGrounded = false;

        public PuzzleManager manager;
        [Header("Properties"), SerializeField] CharacterController controller;
        [SerializeField] Animator animator;
        [SerializeField] float walkSpeed = 5f;
        [SerializeField] float runSpeed = 10f;
        [SerializeField] float gravityScale = 1f;
        [SerializeField] float jumpHeight = 8f;

        [Header("Settings")]
        [SerializeField] LayerMask groundMask;
        [SerializeField] MoveAir moveAir = MoveAir.Moveable;
        [SerializeField] AnimatorOverrideController[] controllers;

        [Header("Controlls"), SerializeField] KeyCode jumpKeyCode = KeyCode.Space;
        [SerializeField] KeyCode runKeyCode = KeyCode.LeftShift;
        [SerializeField] KeyCode portalGear = KeyCode.KeypadEnter;

        public float Speed => IsRunning ? runSpeed : walkSpeed;
        public bool IsRunning => Input.GetKey(runKeyCode);
        public bool IsMoving { get; set; }

        public Vector3 posY;
        public float launchSpeed = 10f;

        //
        AudioSource _audioSource;   
        [SerializeField] GameObject[] platforms;
        bool doubleJump = false;
        bool tripleJump = false;
        Rigidbody _rb;
 
    

        private void Start()
        {

            col = controller.GetComponent<Collider>();
            cam = Camera.main.transform;
            _audioSource = GetComponent<AudioSource>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            IsGrounded();
            Inputs();
            SoundManager.Instance.Timer -= Time.deltaTime;
            if(PuzzleManager.Instance.isPuzzleActive == false)
            {
                if (IsMoving)
                {
                    LookAtCamera();
                    SoundManager.Instance.SoundPlayOneShot();
                    transform.GetChild(0).GetComponent<Animator>().SetBool("walk", true);
                }
                else
                {
                    transform.GetChild(0).GetComponent<Animator>().SetBool("walk", false);
                }
                if (Input.GetKey(runKeyCode))
                {
                    transform.GetChild(0).GetComponent<Animator>().SetBool("run", true);
                    SoundManager.Instance.SoundPlayOneShot();
                    Movement();
                }
                else
                {
                    transform.GetChild(0).GetComponent<Animator>().SetBool("run", false);
                }

                Gravity();
                Movement();
                controller.Move(velocity * Time.deltaTime);
            }
        }

        private void IsGrounded()
        {
            // Is grounded
            isGrounded = IsGroundedSphere(col, controller.radius, groundMask, true);

            if (isGrounded && velocity.y < 0)
                velocity.y = -5f;

            animator.SetBool("Float", !isGrounded);
        }

        private void Inputs()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                if (manager.isPuzzleActive == false)
                    Jump();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                //play C
                _audioSource.PlayOneShot(SoundManager.Instance.sounds[1]);

                if(controller.isGrounded)
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

                if (controller.isGrounded)
                {
                    //Dash();
 
                }
                else if(!controller.isGrounded && doubleJump)
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


                if (!controller.isGrounded && tripleJump)
                {
                    GameObject newPlatform = Instantiate(platforms[1], transform.position - Vector3.up, Quaternion.identity);
                    Jump();
                    StartCoroutine(DestroyPlatform(newPlatform));
                    tripleJump=false;
                }
            }
          
        }

        private void Gravity()
        {
            velocity.y = velocity.y + GRAVITY * gravityScale * Time.deltaTime;
        }

        private void Movement()
        {
            const float IS_MOVING_MIN_MAG = .02f;

            if (moveAir == MoveAir.NotMoveable && !isGrounded)
                return;

            var moveX = Input.GetAxis("Horizontal");
            var moveY = Input.GetAxis("Vertical");

            // Hareket vektörü
            var move = new Vector3(moveX, 0, moveY).normalized;

            animator.SetFloat("MoveX", GetAnimMoveVal(moveX, animator.GetFloat("MoveX")));
            animator.SetFloat("MoveY", GetAnimMoveVal(moveY, animator.GetFloat("MoveY")));

            if (move.magnitude >= IS_MOVING_MIN_MAG)
            {
                // Karakteri hareket yönüne döndür
                transform.rotation = Quaternion.LookRotation(move);
                // Karakteri hareket ettir
                controller.Move(move * Speed * Time.deltaTime);
            }

            IsMoving = move.magnitude >= IS_MOVING_MIN_MAG;
        }
        private void Jump()
        {
            SoundManager.Instance.SoundPlay(0);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY * gravityScale);
            
        }

        private void LookAtCamera()
        {
            const float SMOOTH_TIME = 5f;
            var camAngles = Packtool.Vector3X.IgnoreXZ(cam.eulerAngles);
            var targetRot = Quaternion.Euler(camAngles);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, SMOOTH_TIME * Time.deltaTime);
        }


        #region Controller

        private void UseNextController()
        {
            currentController = (currentController + 1) % controllers.Length;
            OnCurrentControllerChange?.Invoke(currentController);
            
        }

        private void UsePreviousController()
        {
            if (currentController > 0)
                currentController--;
            else currentController = controllers.Length - 1;

            OnCurrentControllerChange?.Invoke(currentController);
           
        }
        #endregion

        float GetAnimMoveVal(float move, float animCurVal)
        {
            const float SMOOTH_TIME = 10f;
            const float WALK_VAL = 1f;
            const float RUN_VAL = 2f;
            var newVal = move * (IsRunning ? RUN_VAL : WALK_VAL);
            var res = Mathf.Lerp(animCurVal, newVal, SMOOTH_TIME * Time.deltaTime);
            return newVal;
        }

        //Platform destroyer SSSSsSSSSSSSSs
        IEnumerator DestroyPlatform(GameObject obj)
        {
            yield return new WaitForSeconds(1f);

            Destroy(obj);

            
        }


    }


}
