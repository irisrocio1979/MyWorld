using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    public float playerSpeed = 7.0f;
    public float jumpForce = 10.0f;
    public float stepDown = 30.0f;
    public float fallSlopeVelocity = 8f;
    public float fallSlopeForce = 10.0f;

    [HideInInspector]
    public bool safeZone;
    [HideInInspector]
    public bool IsRunning;
    [HideInInspector]
    public bool IsWalking;

    private Vector3 m_PlayerMovement;
    private Vector3 m_Movement;
    private Vector2 touchStartPosition;
    private MLInput.Controller mlInputController;
    Vector3 m_HitNormal;
    public float touchpadSensitivity = 0.15f;
    public bool ataque;
    bool m_OnSlope = false; 
    float m_Speed;              //  Speed of the player, this changes if the player run
    float m_Gravity = 20.0f;    //  Gravity
    float m_FallVelocity;       //  Variable that saves and applies gravity to the player

    private bool m_IsJump; // Se agrega la variable m_IsJump

    public AudioSource runningSound;
    public AudioSource collisionSound;

    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        MLInput.Start();
        mlInputController = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnDestroy()
    {
        MLInput.Stop();
    }

    void Update()
    {
        if (mlInputController != null && mlInputController.Touch1Active)
        {
            Vector2 touchDeltaPosition = (Vector2)mlInputController.Touch1PosAndForce - touchStartPosition;
            Vector3 movement = new Vector3(touchDeltaPosition.x, 0f, touchDeltaPosition.y) * touchpadSensitivity;
            controller.Move(movement * playerSpeed * Time.deltaTime);
        }

        Gravity();
        Jump();

        if (Input.GetKeyDown(KeyCode.Return) && !ataque)
        {
            m_Animator.SetTrigger("golpeo");
        }

        if (controller.isGrounded && !m_IsJump)
        {
            m_PlayerMovement = m_PlayerMovement + Vector3.down * stepDown;
        }

        controller.Move(m_PlayerMovement * Time.deltaTime);

        if (IsMoving())
        {
            Action();
        }
        else
        {
            m_Animator.SetFloat("Speed", 0);
        }
    }

    void Gravity()
    {
        if (controller.isGrounded)
        {
            m_PlayerMovement.y = -fallSlopeVelocity * Time.deltaTime;
            m_IsJump = false; // Se establece m_IsJump en false si el jugador está en el suelo
        }
        else
        {
            m_PlayerMovement.y -= fallSlopeVelocity * Time.deltaTime;
            m_Animator.SetFloat("AirSpeed", controller.velocity.y);
            if (controller.velocity.y <= -25 || controller.velocity.y >= 20)
            {
                m_Animator.SetTrigger("Jump");
            }
            m_IsJump = true; // Se establece m_IsJump en true si el jugador está en el aire
        }
        m_Animator.SetBool("IsGrounded", controller.isGrounded);
        FallSlope();
    }

    void Jump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            m_PlayerMovement.y = jumpForce;
            m_Animator.SetTrigger("Jump");
            m_IsJump = true; // Se establece m_IsJump en true cuando el jugador salta
        }
    }

    void FallSlope()
    {
        float slopeAngle = Vector3.Angle(m_HitNormal, Vector3.up);
        m_OnSlope = slopeAngle > controller.slopeLimit && slopeAngle < 89;

        if (m_OnSlope)
        {
            m_PlayerMovement.x += ((1f - m_HitNormal.y) * m_HitNormal.x) * fallSlopeVelocity;
            m_PlayerMovement.z += ((1f - m_HitNormal.y) * m_HitNormal.z) * fallSlopeVelocity;
            m_PlayerMovement.y -= fallSlopeForce;
        }
    }

    bool IsMoving()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        return horizontalMove != 0f || verticalMove != 0f;
    }

    void Action()
    {
        if (Input.GetButton("Sprint"))
        {
            m_Speed = playerSpeed * 1.5f;
            IsWalking = false;
            IsRunning = true;
            m_Animator.SetFloat("Speed", controller.velocity.magnitude);

            if (!runningSound.isPlaying)
            {
                runningSound.Play();
            }
        }
        else
        {
            m_Speed = playerSpeed;
            IsRunning = false;
            IsWalking = true;
            m_Animator.SetFloat("Speed", controller.velocity.magnitude);
            runningSound.Stop();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        m_HitNormal = hit.normal;
    }
}
