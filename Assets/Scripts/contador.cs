using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contador : MonoBehaviour
{
    public calculator Calculator;
    

    public int counter;
    public Text textCounter;

    void Start()
    {
        textCounter = GetComponent<Text>();
        counter = 00;
    }

    void Update()
    {
        if (counter < 10)
        {
            textCounter.text = "0" + counter.ToString();
        }
        else
        {
            textCounter.text = counter.ToString();
        }
    }
}
