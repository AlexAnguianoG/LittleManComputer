using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunScript : MonoBehaviour
{
    public calculator Calculator;
    public contador Counter;
    public ConsoleScript ConsoleLog;
    List<GameObject> mailboxes = new List<GameObject>();
    public Button runButton;
    public Button InputButton;
    public Button InputInterruptButton;
    public Button InputStepButton;
    public Button InterruptEnterB;
    public Button InterruptStepB;
    public Button RunB;
    public Button OneStepB;
    bool stop = false;
    public bool isInputBtnPressed = false;
    public bool interruptF = false;
    public int numberC;
    public int numCon;
    public int numCBeforeIntrrupt = 0;
    public int calcBeforeIntrrupt = 0;

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

        InputButton.gameObject.SetActive(false);
        InterruptEnterB.gameObject.SetActive(false);
        InterruptStepB.gameObject.SetActive(false);
        InputStepButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void runB(int numC)
    {
        refillInputField();
        bool isIndexZero = false;
        stop = false;

        while (isIndexZero == false)
        {
            if(interruptF == true)
            {
                numC = numCBeforeIntrrupt;
                Calculator.calculatorn.text = calcBeforeIntrrupt.ToString();
                interruptF = false;
            }
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
                        InputButton.gameObject.SetActive(true);
                        isIndexZero = true;
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
        }

    }

    public void inputBtnPressed()
    {
        Calculator.calculatorn.text = GameObject.Find("TextInput").GetComponent<Text>().text;
        InputButton.gameObject.SetActive(false);
        runB(Counter.counter);
    }

    public void inputInterruptBtnPressed()
    {
        Calculator.calculatorn.text = GameObject.Find("TextInput").GetComponent<Text>().text;
        ConsoleLog.consoleLog("Number read from the input and copied to calculator display.");
        InputInterruptButton.gameObject.SetActive(false);
        OneStepB.gameObject.SetActive(true);
    }

    public void inputStepBtnPressed()
    {
        Calculator.calculatorn.text = GameObject.Find("TextInput").GetComponent<Text>().text;
        ConsoleLog.consoleLog("Number read from the input and copied to calculator display.");
        InputStepButton.gameObject.SetActive(false);
        OneStepB.gameObject.SetActive(true);
        InterruptStepB.gameObject.SetActive(true);
    }


    public void interruptBtn()
    {
        int pCounter = Int32.Parse(GameObject.Find("TextIFInterrupt").GetComponent<Text>().text);
        ConsoleLog.consoleLog("Begin of the interrupt handler in mailbox " + pCounter.ToString() + ".");
        InterruptEnterB.gameObject.SetActive(false);
        Counter.counter = pCounter;
        interrupt(pCounter);
        InterruptStepB.gameObject.SetActive(true);
    }

    public void interruptBtnStep()
    {
        interrupt(Counter.counter);
        InterruptStepB.gameObject.SetActive(true);
    }

    public void interrupt(int numC)
    {
        refillInputField();
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
                    
                    InputInterruptButton.gameObject.SetActive(true);
                    InputButton.gameObject.SetActive(false);
                    InterruptEnterB.gameObject.SetActive(false);
                    InterruptStepB.gameObject.SetActive(false);
                }
                else if (mB.Substring(2) == "2")
                {
                    ConsoleLog.consoleLog("Calculator value copied to the output.");
                    GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text = GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text + "\n" + Calculator.calculatorn.text;
                }
                else if (mB == "999")
                {
                    ConsoleLog.consoleLog("End of the interrupt handler.");
                    RunB.gameObject.SetActive(true);
                    OneStepB.gameObject.SetActive(true);
                    InterruptEnterB.gameObject.SetActive(true);
                    InterruptEnterB.gameObject.SetActive(false);
                    InterruptStepB.gameObject.SetActive(false);
                    GameObject.Find("InterruptToggle").GetComponent<Toggle>().isOn = false;
                    Calculator.calculatorn.text = calcBeforeIntrrupt.ToString();
                    Counter.counter = numCBeforeIntrrupt;
                }
                break;
        }
       
    }


    public void stepB(int numC)
    {
        refillInputField();
        stop = false;
        numC = Counter.counter;
        if (interruptF == true)
        {
            numC = numCBeforeIntrrupt;
            Calculator.calculatorn.text = calcBeforeIntrrupt.ToString();
            interruptF = false;
        }

        if (GameObject.Find("InterruptToggle").GetComponent<Toggle>().isOn == true)
        {
            interruptF = true;
            numCBeforeIntrrupt = numC;
            calcBeforeIntrrupt = Int32.Parse(Calculator.calculatorn.text);
            InterruptEnterB.gameObject.SetActive(true);//gameObject.SetActive(true);
            RunB.gameObject.SetActive(false);
            OneStepB.gameObject.SetActive(false);
            Counter.counter = 0;
            Calculator.calculatorn.text = "000";
            ConsoleLog.consoleLog("Interrupt handler activated.");
            return;
        }

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
                    InputStepButton.gameObject.SetActive(true);
                    OneStepB.gameObject.SetActive(false);
                    RunB.gameObject.SetActive(false);
                }
                else if (mB.Substring(2) == "2")
                {
                    ConsoleLog.consoleLog("Calculator value copied to the output.");
                    GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text = GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text + "\n" + Calculator.calculatorn.text;
                }
                break;
        }
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
        OneStepB.gameObject.SetActive(true);
        RunB.gameObject.SetActive(true);
        InputButton.gameObject.SetActive(false);
        InterruptEnterB.gameObject.SetActive(false);
        InterruptStepB.gameObject.SetActive(false);
        InputStepButton.gameObject.SetActive(false);
        GameObject.Find("Output").GetComponentsInChildren<Text>()[1].text = "";
        ConsoleLog.consoleLogText.text = "";
    }

    public void printConsole(string newLine)
    {
        GameObject.Find("ConsoleInfo").GetComponent<Text>().text = newLine + "\n" + GameObject.Find("ConsoleInfo").GetComponent<Text>().text;
    }

    public void refillInputField()
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
    }
}

