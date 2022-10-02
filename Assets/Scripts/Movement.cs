using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 3.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    Vector3 velocity;
    public bool isGrounded = true;
    bool JumpBoost = false;

    float JumpBoostTimer = 0.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Rigidbody rb;

    PlayerScript player;

    bool wasGrounded;
    bool wasFalling;
    float startOfFall;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame

    void onTriggerEnter(Collision enter)
    {
        
    }

    void onTriggerExit(Collision exit)
    {
        
    }

    void Update()
    {
        JumpBoost = IsOnGround(7);

        if (JumpBoost && JumpBoostTimer == 0.0f)
        {
            jumpHeight = 6.0f;
        }

        isGrounded = IsOnGround(3);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            JumpBoost = false;
            jumpHeight = 2.0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || JumpBoost)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (IsOnGround(8))
        {
            player.death();
        }

        if (IsOnGround(9))
        {
            player.JarLid();
        }

        if(!wasFalling && isFalling)
        {
            startOfFall = transform.position.y;
        }

        if(!wasGrounded && isGrounded)
        {
            FinishedFalling();
        }

        wasFalling = isFalling;
        wasGrounded = isGrounded;
    }

    public bool IsOnGround(int layer)
    {
        int layerMask = 1 << layer;

        //layerMask = 1 << 7;

        RaycastHit hit;

        if (Physics.Raycast(rb.worldCenterOfMass, -transform.up, out hit, 0.25f, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void FinishedFalling()
    {
        //Debug.Log("Player fell" + (startOfFall - transform.position.y) + " units");
        if(startOfFall - transform.position.y > 2.5f)
        {
            player.death();
        }
    }

    bool isFalling { get { return (!isGrounded && rb.velocity.y < 0);  } }
}
