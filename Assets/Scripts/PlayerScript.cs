using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public bool JumpBoost = false;
    Movement script;

    public float timer = 60.0f;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "0.00";
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

        

        if (timer <= 0)
        {

            death();
        }
        else
        {
            timer -= Time.deltaTime;
            ScoreText.text = timer.ToString("0.00");
        }
    }


    public void death()
    {
        Debug.Log("Death");
        FindObjectOfType<gameManager>().EndGame();
    }

    public void JarLid()
    {
        Debug.Log("You win!");
        FindObjectOfType<gameManager>().WinGame();
    }
    // Update is called once per frame
}
