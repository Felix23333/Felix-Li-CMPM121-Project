using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public int targetPhase;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<ClockRotate>().GetCurrentPhase() != targetPhase)
            {
                other.gameObject.GetComponent<PlayerController>().Respawn();
            }
        }
    }
}
