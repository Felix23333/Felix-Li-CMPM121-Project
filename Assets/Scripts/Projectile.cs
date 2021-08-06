using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    public int destoryTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestorySelf());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator DestorySelf()
    {
        yield return new WaitForSeconds(destoryTime);
        if(gameObject)
        {
            Destroy(gameObject);
        }
        
    }
}
