using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cheat : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public Text scoreText;
    
    public void OpenDoor()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        door3.SetActive(false);
    }

    public void CanICheat()
    {
        scoreText.text = "NO! You Cheater!";
    }

    public void Felix()
    {
        scoreText.text = "This is Felix's CMPM121 Project!";
    }
    
}
