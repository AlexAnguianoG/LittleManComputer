using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class calculator : MonoBehaviour
{
    public Text calculatorn;
    public Image isZeroRed;
    public Image isPositiveRed;
  
    void Start()
    {
        
    }

    void Update()
    {
        try
        {
            if (Int32.Parse(calculatorn.text) == 0)
            {
                isZeroRed.enabled = false;
            }
            else
            {
                isZeroRed.enabled = true;
            }

            if (Int32.Parse(calculatorn.text) >= 0)
            {
                isPositiveRed.enabled = false;
            }
            else
            {
                isPositiveRed.enabled = true;
            }
        }
        catch(FormatException)
        {

        }


    }

    

}
