using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    public Text consoleLog;

    // Start is called before the first frame update
    void Start()
    {
        consoleLog = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
