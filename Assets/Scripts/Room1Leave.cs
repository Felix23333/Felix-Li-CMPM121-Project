using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Leave : MonoBehaviour
{
    public Room1 room1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            room1.Player.SetActive(true);
            room1.Player2D.SetActive(false);
            room1.cameraController.SwitchCamera();
        }
    }
}
