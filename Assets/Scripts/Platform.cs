using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Material normalMat;
    public Material lightMat;
    public int targetPhase;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNormal()
    {
        GetComponent<MeshRenderer>().material = normalMat; 
    }

    public void SetLight()
    {
        GetComponent<MeshRenderer>().material = lightMat;
    }
}
