using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int PlayersAlive = 4;
    public float resetTimer = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        

       if (PlayersAlive == 1)
        {            
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                PlayersAlive = 0;
                SceneManager.LoadScene ("shadow_prototype");
            }
            
        }
        
    }
}
