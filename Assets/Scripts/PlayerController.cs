using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10;
    CharacterController controller;
    public float gravity = 9.8f;
    //projectile shoot vars
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    //raycast shoot vars
    public Transform raycastPoint;
    Ray ray;

    //temp var
    float dirY;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //handle jump and move
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(controller.isGrounded)
        {
            dirY = Input.GetAxis("Jump") * jumpHeight;
        }


        dirY -= gravity * Time.deltaTime;
        dir.y = dirY;
        controller.Move(dir * Time.deltaTime * speed);
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
                hit.collider.gameObject.GetComponent<EnemyController>().PlayHurtEffect();
            }
        }
    }
}
