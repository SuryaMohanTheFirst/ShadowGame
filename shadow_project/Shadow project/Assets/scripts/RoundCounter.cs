using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public static int P1Wins;
    public static int P2Wins;
    public static int P3Wins;
    public static int P4Wins;
    public int Win = 3;    
    public bool EndRound = true;

    // Start is called before the first frame update
    void Start()
    {    
        EndRound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndRound == true && player2.GetComponent<Bandit1>().killed == true && player3.GetComponent<Bandit3>().killed == true && player4.GetComponent<Bandit4>().killed == true)
        {
            P1Wins += 1;
            EndRound = false;
        }

        if (EndRound == true && player1.GetComponent<Bandit>().killed == true && player3.GetComponent<Bandit3>().killed == true && player4.GetComponent<Bandit4>().killed == true)
        {
            P2Wins += 1;
            EndRound = false;
        }

        if (EndRound == true && player1.GetComponent<Bandit>().killed == true && player2.GetComponent<Bandit1>().killed == true && player4.GetComponent<Bandit4>().killed == true)
        {
            P3Wins += 1;
            EndRound = false;
        }

        if (EndRound == true && player1.GetComponent<Bandit>().killed == true && player2.GetComponent<Bandit1>().killed == true && player3.GetComponent<Bandit3>().killed == true)
        {
            P4Wins += 1;
            EndRound = false;
        }

        if (P1Wins >= Win || P2Wins >= Win || P3Wins >= Win || P4Wins >= Win)
        {

        }
    }
}
