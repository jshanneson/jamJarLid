using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePush : MonoBehaviour
{
    //force float value
    [SerializeField]
    private float forceMaginitude;


    //when colliding with an object, this will run
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            //find direction vector of force to apply
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0; //don't push up
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMaginitude, transform.position, ForceMode.Impulse);

        }
    }
}
