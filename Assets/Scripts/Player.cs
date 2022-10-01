using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool JumpBoost = false;
    Movement script; 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void onCollisionEnter(Collision enter)
    {
        if(enter.gameObject.layer == 7)
        {
            JumpBoost = true;
            Debug.Log("Layer 7");
        }

        if(enter.gameObject.layer == 8)
        {
            Debug.Log("Layer 8");
        }
    }

    void onCollisionExit(Collision exit)
    {
        if (exit.gameObject.layer == 7)
        {
            JumpBoost = false;
        }
    }
    // Update is called once per frame
}
