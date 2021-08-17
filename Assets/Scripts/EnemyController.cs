using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public bool isFollowing;
    Vector3 initPos;
    public int health;
    /*public bool canShoot = false;
    public float shootDistance;*/
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
        if(agent)
        {
            if (isFollowing)
            {
                agent.destination = target.transform.position;
            }
            else
            {
                agent.destination = initPos;
            }
        }
        
    }

    public void PlayHurtEffect()
    {
        StartCoroutine(HurtEffect());
    }

    IEnumerator HurtEffect()
    {
        health--;
        GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<MeshRenderer>().material.color = new Color(1, 0.23f, 0.76f);
    }

    
}
