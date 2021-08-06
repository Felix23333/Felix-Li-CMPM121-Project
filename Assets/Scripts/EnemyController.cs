using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float xMax;
    public float xMin;
    public float speed = 10;
    bool trigger = false;
    int count;
    bool isLock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count >= 50)
        {
            isLock = false;
        }
        if (trigger)
        {
            speed = -speed;
            trigger = false;
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > xMax || transform.position.x < xMin)
        {
            if (!isLock)
            {
                trigger = true;
                isLock = true;
                count = 0;
            }
        }
    }

    public void PlayHurtEffect()
    {
        StartCoroutine(HurtEffect());
    }

    IEnumerator HurtEffect()
    {
        GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<MeshRenderer>().material.color = new Color(1, 0.23f, 0.76f);
    }

    
}
