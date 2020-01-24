using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private int randVal;
    private int remainder;

    // Start is called before the first frame update
    void Start()
    {
        randVal = Random.Range(1, 11);
        Debug.Log(randVal);
        remainder = randVal % 2;
        Debug.Log(remainder);
        if (remainder == 1)
        {
            
        }
        else if (remainder == 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
