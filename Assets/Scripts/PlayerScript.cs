using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool JumpBoost = false;
    Movement script;

    float timer = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void onTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {

        //Debug.Log(timer);

        if (timer <= 0)
        {

            death();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }


    public void death()
    {
        Debug.Log("Death");
    }

    public void JarLid()
    {
        Debug.Log("You win!");
    }
    // Update is called once per frame
}
