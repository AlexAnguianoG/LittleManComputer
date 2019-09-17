using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConsoleScript : MonoBehaviour
{
    public Text consoleLogText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void consoleLog(string newLine)
    {
        consoleLogText.text = newLine + "\n" + consoleLogText.text;
    }
}
