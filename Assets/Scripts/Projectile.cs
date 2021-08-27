using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    public int destoryTime = 3;
    Transform player;
    Vector3 shootDir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestorySelf());
        shootDir = player.transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(shootDir * speed * Time.deltaTime, ForceMode.Impulse);
        //Debug.Log(shootDir);
    }

    IEnumerator DestorySelf()
    {
        yield return new WaitForSeconds(destoryTime);
        if(gameObject)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().PlayHurtEffect();
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Ignore")
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
