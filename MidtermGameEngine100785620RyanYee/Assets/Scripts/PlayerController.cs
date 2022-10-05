using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //=================
    //movement
    //=================
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float jump = 5f;
    private float walkSpeed = 10f;
    private float step = 10f;
    Vector3 previousPosition;
    public Camera playercam;
    private bool movingL = false;

    private bool movingR = false;


    Vector3 cameraRotation;
    //=================
    //jump
    //=================
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;


    //=================
    //animator
    //=================
    Animator playerAnimator;
    private bool isWalking = false;

    //=================
    //projectile
    //=================
    public GameObject bullet;
    public Transform projectilePos;

    private void OnEnable()
    {

        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();
        inputAction.Player.DodgeR.performed += cntxt => dodgeR();
        inputAction.Player.DodgeL.performed += cntxt => dodgeL();

        inputAction.Player.Shoot.performed += cntxt => Shoot();


        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }
    private void dodgeL()
    {
        rb.velocity = new Vector2(-step, rb.velocity.y);
        Debug.Log("moving left");
    }
    private void dodgeR()

    {
        rb.velocity = new Vector2(step, rb.velocity.y);       
        Debug.Log("moving right");
          
     }




    
    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

  
    // Update is called once per frame
    void Update()
    {

        cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);
        playercam.transform.rotation = Quaternion.Euler(cameraRotation);
        transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
        Vector3 moveRun = new Vector3(move.x, 0, move.y);
        animateRunning(moveRun);


    }

    void animateRunning(Vector3 moveRun)
    {
        isWalking = (moveRun.x > 0.1f || moveRun.x < -0.1f) || (moveRun.z > 0.1f || moveRun.z < -0.1f) ? true : false;
        playerAnimator.SetBool("isWalking", isWalking);
    }
}