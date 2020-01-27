using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject);
        Debug.Log("Running");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("This works");
        if (other.tag == "Player")
            Debug.Log("This is a Player");
        {
            if (other.gameObject == player2)
            {
                player2.GetComponent<Bandit1>().killed = true;
            }

            if (other.gameObject == player1)
            {
                player1.GetComponent<Bandit>().killed = true;
            }
        }
    }
}
