using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera thirdPerson;
    public Camera firstPerson;
    // Start is called before the first frame update
    void Start()
    {
        thirdPerson.enabled = true;
        firstPerson.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        if(thirdPerson.enabled)
        {
            thirdPerson.enabled = false;
            firstPerson.enabled = true;
        }
        else
        {
            thirdPerson.enabled = true;
            firstPerson.enabled = false;
        }
    }
}
