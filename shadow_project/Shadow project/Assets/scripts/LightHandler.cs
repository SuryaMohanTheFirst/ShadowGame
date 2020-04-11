using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHandler : MonoBehaviour
{
    private int randVal;
    private int remainder;
    public float swapTime;
    public GameObject backingLight;
    public bool shadow;

    // Start is called before the first frame update
    void Start()
    {
        randVal = Random.Range(1, 11);
        remainder = randVal % 2;
        if (remainder == 1)
        {
            backingLight.SetActive(true);
            shadow = false;
        }
        else if (remainder == 0)
        {
            backingLight.SetActive(false);
            shadow = true;
        }

        InvokeRepeating("swapLight", swapTime, swapTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void swapLight()
    {
        if (backingLight.activeSelf)
        {
            backingLight.SetActive(false);
            shadow = true;
        } else
        {
            backingLight.SetActive(true);
            shadow = false;
        }
    }
}
