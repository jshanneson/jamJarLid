using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextScript : MonoBehaviour
{
    public float disappearDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Disappear", disappearDelay);
    }

    void Disappear ()
    {
        Destroy (gameObject);
    }

}
