using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is based on https://www.youtube.com/watch?v=XAskJv_CGbg
public class CheatCodeManager : MonoBehaviour
{
    [SerializeField]
    private bool playerTyping = false;
    [SerializeField]
    private string currentString = "";

    [SerializeField]
    private List<CheatCodeInstance> cheatCodeList = new List<CheatCodeInstance>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (playerTyping)
            {
                CheckCheat(currentString);
            }

            playerTyping = !playerTyping;
        }

        if(playerTyping)
        {
            foreach(char c in Input.inputString)
            {
                if(c == '\b')
                {
                    if(currentString.Length > 0)
                    {
                        currentString = currentString.Substring(0, currentString.Length - 1);
                    }
                }
                else if(c == '\n' || c == '\r')
                {
                    currentString = "";
                }
                else
                {
                    currentString += c;
                }
            }
        }
    }

    private bool CheckCheat(string _input)
    {
        foreach (CheatCodeInstance code in cheatCodeList)
        {
            if(_input == code.code)
            {
                code.cheatEvent?.Invoke();
                return true;
            }
        }
        return false;
    }
}
