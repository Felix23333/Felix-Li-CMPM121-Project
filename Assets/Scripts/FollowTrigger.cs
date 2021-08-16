using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            foreach (var enemy in enemies)
            {
                enemy.isFollowing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            foreach (var enemy in enemies)
            {
                enemy.isFollowing = false;
            }
        }
    }
}
