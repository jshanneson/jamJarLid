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

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Rigidbody rb;

    // Update is called once per frame

    void onTriggerEnter(Collision enter)
    {
        if (enter.gameObject.layer == 7)
        {
            JumpBoost = true;
            rb.AddForce(Vector3.up * 4.0f, ForceMode.Impulse);
            //Debug.Log("Layer 7");
        }

        if (enter.gameObject.layer == 8)
        {
            //Debug.Log("Layer 8");
        }
    }

    void onTriggerExit(Collision exit)
    {
        if (exit.gameObject.layer == 7)
        {
            JumpBoost = false;
        }
    }

    void Update()
    {
        //jump
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log(velocity.y);
        if (JumpBoost)
        {
            jumpHeight = 6.0f;
        }

        isGrounded = IsOnGround();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
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
    }

    bool IsOnGround()
    {
        int layerMask = 1 << 3;

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
}
