using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoJump : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;
    Vector3 velocity;
    // On Trigger is caller when the player touches the trigger
    void OnTriggerEnter(Collider player)
    {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            controller.Move(velocity * Time.deltaTime);
    }

}
