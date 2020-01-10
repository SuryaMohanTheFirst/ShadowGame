using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOnOff : MonoBehaviour
{
    public Light spotlight;

    Light mylight;
    public bool playeronSpot = false;
    public float Darkintensity;
    public float BrightIntensity;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown("joystick button 3"))
        {
            if (playeronSpot)
            {
                spotlight.intensity = Darkintensity;
               
            }
            if (playeronSpot == false)
            {
                spotlight.intensity = BrightIntensity;
            }




        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          //  if (Input.GetKeyDown("joystick button 2"))
         //   {
                playeronSpot = true;
          //  }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playeronSpot = false;
        }
    }

}
