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
        currentPhase = -1;
        InvokeRepeating("ChangePhase", 0, 3);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-speed * Time.deltaTime, 0f, 0f);
    }

    void ChangePhase()
    {
        currentPhase++;
        currentPhase = currentPhase % 3;
        Platform[] platforms = FindObjectsOfType<Platform>();
        foreach (Platform platform in platforms)
        {
            if(platform.targetPhase == currentPhase)
            {
                platform.SetLight();
            }
            else
            {
                platform.SetNormal();
            }
        }
    }
}
