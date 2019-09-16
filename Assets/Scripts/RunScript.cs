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
    public InputField mailbox;
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
        do
        {
            int numC = 0;
            string mB = mailboxes[numC].GetComponent<Text>().text;

            /*switch (mailbox.text.Substring(0, 1))*/

            switch (mB.Substring(0, 1))
            {
                case "0":
                    isIndexZero = true;
                    break;
                case "1":
                    numberC = Int32.Parse(Calculator.calculatorn.text) + Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    isIndexZero = false;
                    break;
                case "2":
                    numberC = Int32.Parse(Calculator.calculatorn.text) - Int32.Parse(mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponent<Text>().text);
                    Calculator.calculatorn.text = numberC.ToString();
                    isIndexZero = false;
                    break;
                case "3":
                    
                    /*GameObject.Find("Text10").GetComponent<Text>().text = "10";*/
                    /*p.text = "10";*/

                    /*mailboxes[Int32.Parse(mB.Substring(1,2))].GetComponent<Text>().text = Calculator.calculatorn.text;*/
                    /*mailboxes[10].GetComponent<Text>().text = "89";
                    Debug.Log(mailboxes[10].GetComponent<Text>().text);*/
                  /*  Text prueba = mailboxes[Int32.Parse(mB.Substring(1, 2))].GetComponentInChildren<Text>();
                    prueba.text = "42";*/

                    mailboxes[Int32.Parse(mB.Substring(1,2))].GetComponent<Text>().text = Calculator.calculatorn.text.Substring(1,2);
                    isIndexZero = false;
                    break;
                case "4":
                    break;
                case "5": 
                    Calculator.calculatorn.text = mailbox.text.Substring(1, 2);
                    isIndexZero = false;

                    break;


            }

            numC++;


        } while (isIndexZero == false);

    }
}
