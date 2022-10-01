using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    public CharacterController controller;
    private float gravityValue = -9.81f;
    private bool groundedPlayer;
    //private PlayerMotor motor;
    private bool grounded = false;
    Rigidbody rb;
    private bool jump_pressed = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform camera;
    private Vector3 PlayerVelocity;


    void MovementJump()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPLayer)
        {
            PlayerVelocity.y = 0.0f;
        }

        if(jump_pressed && groundedPlayer)
        {
            PlayerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jump_pressed = false;
        }

        PlayerVelocity.y += gravityValue * Time.deltaTime;
        controller.move(PlayerVelocity * time);

        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;


        if(controller.velocity.y == 0)
        {
            
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;// normalize: Can't go faster if horizontal and vertical keys are pressed

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + camera.eulerAngles.y; //arctan
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
}
