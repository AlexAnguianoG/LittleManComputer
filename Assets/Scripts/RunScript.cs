using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunScript : MonoBehaviour
{

    public Button runButton;
    public int numberC;
    public calculator Calculator;
    public bool isInputBtnPressed = false;
    //public Text CounterText;
    public contador Counter;
    bool stop = false;
    public ConsoleScript ConsoleLog;
    //bool inputSet = false;
    public int numCon;


    //public InputField mailbox;
    List<GameObject> mailboxes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 99; i++)
        {
            if (i < 10)
            {
                mailboxes.Add(GameObject.Find("Text0" + i.ToString()));
            }
            else
            {
                mailboxes.Add(GameObject.Find("Text" + i.ToString()));
            }

            mailboxes[i].GetComponentInParent<InputField>().text = "000";
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void runB(int numC)
    {
        foreach (GameObject intxt in mailboxes)
        {
            if (intxt.GetComponentInParent<InputField>().text.Length == 1)
            {
                intxt.GetComponentInParent<InputField>().text = "00" + intxt.GetComponentInParent<InputField>().text;
            }
            else if (intxt.GetComponentInParent<InputField>().text.Length == 2)
            {
                intxt.GetComponentInParent<InputField>().text = "0" + intxt.GetComponentInParent<InputField>().text;
            }
        }


        bool isIndexZero = false;


        stop = false;

        while (isIndexZero == false)
        {
            string mB = mailboxes[numC].GetComponent<Text>().text;
            numC++;
            Counter.counter = numC;

            

            switch (mB.Substring(0, 1))
            {

                case "0":
                    if (mB.Substring(1, 2) == "00") {
                        isIndexZero = true;
                    }
                    break;
                case "1":
                    ConsoleLog.consoleLog("Added the contents of mailbox " + mB.Substring(1, 2) + " to the calculator display.");
                    numberC = Int32.Parse(Calculator.calculatorn.text) + Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    break;
                case "2":
                    ConsoleLog.consoleLog("Subtracted the contents of mailbox " + mB.Substring(1, 2) + " from the calculator display.");
                    numberC = Int32.Parse(Calculator.calculatorn.text) - Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    break;
                case "3":
                    ConsoleLog.consoleLog("Stored the calculator value into the mailbox " + mB.Substring(1, 2) + " .");
                    mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text = Calculator.calculatorn.text;
                    break;
                case "4":
                    ConsoleLog.consoleLog("Stored the address portion of the calculator value into the address portion of the instruction in mailbox " + mB.Substring(1, 2) + " .");
                    mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text.Substring(0, 1) + Calculator.calculatorn.text.Substring(1, 2);
                    break;
                case "5":
                    ConsoleLog.consoleLog("Loaded the contents of mailbox " + mB.Substring(1, 2) + " into the calculator.");
                    Calculator.calculatorn.text = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text;
                    break;
                case "6":
                    ConsoleLog.consoleLog("Branched to mailbox " + mB.Substring(1, 2) + ".");
                    numC = Int32.Parse(mB.Substring(1, 2));
                    Counter.counter = numC;
                    break;
                case "7":
                    if (Int32.Parse(Calculator.calculatorn.text) == 0)
                    {
                        ConsoleLog.consoleLog("Calculator value is zero, therefore branched to mailbox " + mB.Substring(1, 2) + " .");
                        numC = Int32.Parse(mB.Substring(1, 2));
                        Counter.counter = numC;
                    }
                    else
                    {
                        ConsoleLog.consoleLog("Calculator value is not zero, therefore not branched.");
                    }
                    break;
                case "8":
                    if (Int32.Parse(Calculator.calculatorn.text) >= 0)
                    {
                        ConsoleLog.consoleLog("Calculator value is positive, therefore branched to mailbox " + mB.Substring(1, 2) + " .");
                        numC = Int32.Parse(mB.Substring(1, 2));
                        Counter.counter = numC;
                    }
                    else
                    {
                        ConsoleLog.consoleLog("Calculator value is not positive, therefore not branched.");
                    }
                    break;
                case "9":
                    if (mB.Substring(2) == "1")
                    {
                        isIndexZero = true;

                        //Calculator.calculatorn.text = GameObject.Find("InputFieldIn").GetComponent<InputField>().text;
                        //ConsoleLog.consoleLog("Number read from the input and copied to calculator display.");
                    }
                    else if (mB.Substring(2) == "2")
                    {
                        ConsoleLog.consoleLog("Calculator value copied to the output.");
                        GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text = GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text + "\n" + Calculator.calculatorn.text;
                    }
                    break;

            }
            if (stop == true)
            {
                isIndexZero = true;
            }
            //System.Threading.Thread.Sleep(1000);
        }

    }

    public void stepB(int numC)
    {
        foreach (GameObject intxt in mailboxes)
        {
            if (intxt.GetComponentInParent<InputField>().text.Length == 1)
            {
                intxt.GetComponentInParent<InputField>().text = "00" + intxt.GetComponentInParent<InputField>().text;
            }
            else if (intxt.GetComponentInParent<InputField>().text.Length == 2)
            {
                intxt.GetComponentInParent<InputField>().text = "0" + intxt.GetComponentInParent<InputField>().text;
            }
        }
        bool isInterrupt = false;
        if (isInterrupt == true)
        {
            
        }

        stop = false;

        numC = Counter.counter;

        
        string mB = mailboxes[numC].GetComponent<Text>().text;
        numC++;
        Counter.counter = numC;

        

        switch (mB.Substring(0, 1))
        {

            case "0":
                break;
            case "1":
                ConsoleLog.consoleLog("Added the contents of mailbox " + mB.Substring(1, 2) + " to the calculator display.");
                numberC = Int32.Parse(Calculator.calculatorn.text) + Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                Calculator.calculatorn.text = numberC.ToString();
                break;
            case "2":
                ConsoleLog.consoleLog("Subtracted the contents of mailbox " + mB.Substring(1, 2) + " from the calculator display.");
                numberC = Int32.Parse(Calculator.calculatorn.text) - Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                Calculator.calculatorn.text = numberC.ToString();
                break;
            case "3":
                ConsoleLog.consoleLog("Stored the calculator value into the mailbox " + mB.Substring(1, 2) + " .");
                mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text = Calculator.calculatorn.text;
                break;
            case "4":
                ConsoleLog.consoleLog("Stored the address portion of the calculator value into the address portion of the instruction in mailbox " + mB.Substring(1, 2) + " .");
                mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text.Substring(0, 1) + Calculator.calculatorn.text.Substring(1, 2);
                break;
            case "5":
                ConsoleLog.consoleLog("Loaded the contents of mailbox " + mB.Substring(1, 2) + " into the calculator.");
                Calculator.calculatorn.text = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text;
                break;
            case "6":
                ConsoleLog.consoleLog("Branched to mailbox " + mB.Substring(1, 2) + ".");
                numC = Int32.Parse(mB.Substring(1, 2));
                Counter.counter = numC;
                break;
            case "7":
                if (Int32.Parse(Calculator.calculatorn.text) == 0)
                {
                    ConsoleLog.consoleLog("Calculator value is zero, therefore branched to mailbox " + mB.Substring(1, 2) + " .");
                    numC = Int32.Parse(mB.Substring(1, 2));
                    Counter.counter = numC;
                }
                else
                {
                    ConsoleLog.consoleLog("Calculator value is not zero, therefore not branched.");
                }
                break;
            case "8":
                if (Int32.Parse(Calculator.calculatorn.text) >= 0)
                {
                    ConsoleLog.consoleLog("Calculator value is positive, therefore branched to mailbox " + mB.Substring(1, 2) + " .");
                    numC = Int32.Parse(mB.Substring(1, 2));
                    Counter.counter = numC;
                }
                else
                {
                    ConsoleLog.consoleLog("Calculator value is not positive, therefore not branched.");
                }
                break;
            case "9":
                if (mB.Substring(2) == "1")
                {

                    //inputReady(numC);

                    //Calculator.calculatorn.text = GameObject.Find("InputFieldIn").GetComponent<InputField>().text;
                    //ConsoleLog.consoleLog("Number read from the input and copied to calculator display.");
                }
                else if (mB.Substring(2) == "2")
                {
                    ConsoleLog.consoleLog("Calculator value copied to the output.");
                    GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text = GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text + "\n" + Calculator.calculatorn.text;
                }
                break;

        }

            //System.Threading.Thread.Sleep(1000);
    }

    public void interrupt()
    {

    }

    

    public void ResetBtnPressed()
    {
        Counter.counter = 0;
    }

    public void StopBtnPressed()
    {
        stop = true;
        Calculator.calculatorn.text = "000";
        Counter.counter = 0;
    }

    public void printConsole(string newLine)
    {
        GameObject.Find("ConsoleInfo").GetComponent<Text>().text = newLine + "\n" + GameObject.Find("ConsoleInfo").GetComponent<Text>().text;
    }

    /*
    public void inputReady(int numC)
    {
        numCon = numC;
    }
    */

    public void inputBtnPressed()
    {
        Calculator.calculatorn.text = GameObject.Find("TextInput").GetComponent<Text>().text;
        runB(Counter.counter);
    }
}
/*
    Interrupt


    ZIP:
    -Ejecutable de unity*
    -Scripts*
    -Manual*
    -README.txt*

    Paso a paso


    poner automaticamente 000 en mailboxes y calculatortext

*/
