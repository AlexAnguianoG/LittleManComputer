using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConsoleScript : MonoBehaviour
{
    public Text consoleLogText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void consoleLog(string newLine)
    {
        consoleLogText.text = newLine + "\n" + consoleLogText.text;
    }
}
