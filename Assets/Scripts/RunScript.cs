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

    public void runB()
    {


        /*
        int n = 99;
        Debug.Log(mailboxes[n].GetComponent<Text>().text);*/

        bool isIndexZero = false;
        
        int numC = 0;
        stop = false;

        while (isIndexZero == false)
        {
            string mB = mailboxes[numC].GetComponent<Text>().text;
            numC++;
            Counter.counter = numC;

            switch (mB.Substring(0, 1))
            {
                case "0":
                    isIndexZero = true;
                    break;
                case "1":
                    numberC = Int32.Parse(Calculator.calculatorn.text) + Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    break;
                case "2":
                    numberC = Int32.Parse(Calculator.calculatorn.text) - Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    break;
                case "3":
                    mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInParent<InputField>().text = Calculator.calculatorn.text;
                    break;
                case "4":
                    break;
                case "5":
                    Calculator.calculatorn.text = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text;
                    break;
                case "6":
                    numC = Int32.Parse(mB.Substring(1, 2));
                    Counter.counter = numC;
                    break;
                case "7":
                    if (Int32.Parse(Calculator.calculatorn.text) == 0)
                    {
                        numC = Int32.Parse(mB.Substring(1, 2));
                        Counter.counter = numC;
                    }
                    break;
                case "8":
                    if (Int32.Parse(Calculator.calculatorn.text) >= 0)
                    {
                        numC = Int32.Parse(mB.Substring(1, 2));
                        Counter.counter = numC;
                    }
                    break;
                case "9":
                    if (mB.Substring(2) == "1")
                    {
                        StartCoroutine("WaitForAction");
                        Calculator.calculatorn.text = GameObject.Find("InputFieldIn").GetComponent<InputField>().text;
                    }
                    else if(mB.Substring(2) == "2")
                    {
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

    public void InBtnPressed() {
        isInputBtnPressed = true;
    }

    public IEnumerable WaitForAction()
    {
        isInputBtnPressed = false; // clear last action, we want a new one
        while (isInputBtnPressed != true) { yield return null; }
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


}
/*
    Consola
    Input
    Interrupt


    ZIP:
    -Ejecutable de unity
    -Scripts
    -Manual
    -README.txt

    Paso a paso


    poner automaticamente 000 en mailboxes y calculatortext





*/
