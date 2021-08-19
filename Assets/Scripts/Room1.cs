using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public Transform teleportDes;
    public GameObject Player;
    public GameObject Player2D;
    public CameraController cameraController;
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
            Player2D.SetActive(true);
            Player.SetActive(false);
            Player.transform.position = teleportDes.transform.position;
            cameraController.SwitchCamera();
        }
    }
}
