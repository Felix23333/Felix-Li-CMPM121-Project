using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    CharacterController controller;
    //projectile shoot vars
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    //raycast shoot vars
    public Transform raycastPoint;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SimpleMove(new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed));
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Fire2();
        }
    }

    void Fire()
    {
        Instantiate(projectilePrefab, spawnPoint);
    }

    void Fire2()
    {
        ray = new Ray(raycastPoint.transform.position, Vector3.forward);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
            }
        }
    }
}
