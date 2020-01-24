using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private int randVal;
    private int remainder;
    public float swapTime;
    public GameObject backingLight;

    // Start is called before the first frame update
    void Start()
    {
        randVal = Random.Range(1, 11);
        Debug.Log(randVal);
        remainder = randVal % 2;
        Debug.Log(remainder);
        if (remainder == 1)
        {
            backingLight.SetActive(true);
        }
        else if (remainder == 0)
        {
            backingLight.SetActive(false);
        }

        InvokeRepeating("swapLight", swapTime, swapTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void swapLight()
    {
        print(backingLight.activeSelf);
        if (backingLight.activeSelf)
        {
            backingLight.SetActive(false);
        } else
        {
            backingLight.SetActive(true);
        }
    }
}
