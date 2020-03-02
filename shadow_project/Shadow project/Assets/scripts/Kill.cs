using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject playersalive;
  
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
                playersalive.GetComponent<GameController>().PlayersAlive -= 1;
            }

            if (other.gameObject == player3)
            {
                player3.GetComponent<Bandit3>().killed = true;
                playersalive.GetComponent<GameController>().PlayersAlive -= 1;
            }

            if (other.gameObject == player1)
            {
                player1.GetComponent<Bandit>().killed = true;
                playersalive.GetComponent<GameController>().PlayersAlive -= 1;
            }

            if (other.gameObject == player4)
            {
                player4.GetComponent<Bandit4>().killed = true;
                playersalive.GetComponent<GameController>().PlayersAlive -= 1;
            }
                            
        }
    }
}
