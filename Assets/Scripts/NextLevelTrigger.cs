using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public GameObject door;
    public AudioSource doorSFX;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(doorSFX)
            {
                doorSFX.Play();
            }
            door.SetActive(false);
        }
    }
}
