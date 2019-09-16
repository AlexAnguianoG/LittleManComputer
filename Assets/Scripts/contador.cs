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
    public Text mailbox;
    public Button runButton;


    // Start is called before the first frame update
    void Start()
    {
        textCounter = GetComponent<Text>();
        counter = 00;
        
    }

    // Update is called once per frame
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
