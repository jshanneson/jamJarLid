using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableObject : MonoBehaviour
{
    public GameObject deathObject;
    // Start is called before the first frame update
    void Start()
    {
        deathObject.SetActive(true);
    }

    // On Trigger is caller when the player touches the trigger
    void OnTriggerEnter(Collider player)
    {
            Debug.Log("trigger activated");
            deathObject.SetActive(false);
    }

}
