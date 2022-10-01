using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 PlayerVelocity;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    public CharacterController controller;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 30.0f;
    private float gravityValue = -9.81f;
    private bool groundedPlayer;
    Rigidbody rb =
    //private PlayerMotor motor;
    private bool grounded = false;
    Rigidbody rb;
    private bool isJumping = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform camera;


    void Start()
    {

        //rb = GetComponent<Rigidbody>();
        //motor = GetComponent<PlayerMotor>();
        //controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float jump = 0f;

        Vector3 direction = new Vector3(horizontal, jump, vertical).normalized;// normalize: Can't go faster if horizontal and vertical keys are pressed
        //Debug.Log(controller.isGrounded);

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
