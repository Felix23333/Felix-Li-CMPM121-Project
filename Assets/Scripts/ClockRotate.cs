using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotate : MonoBehaviour
{
    public float speed;
    int currentPhase;
    // Start is called before the first frame update
    void Start()
    {
        currentPhase = 0;
        InvokeRepeating("ChangePhase", 0, 3);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }

    void ChangePhase()
    {
        currentPhase = currentPhase % 3;
    }
}
