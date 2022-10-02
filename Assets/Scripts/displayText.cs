using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayText : MonoBehaviour
{
    public GameObject npcText;
    // Start is called before the first frame update
    void Start()
    {
        npcText.SetActive(false);
    }

    // On Trigger is caller when the player touches the trigger
    void OnTriggerEnter(Collider player)
    {
            Debug.Log("trigger activated");
            npcText.SetActive(true);
    }

    void OnTriggerExit(Collider player)
    {
        npcText.SetActive(false);
    }
}
