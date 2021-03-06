using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10;
    CharacterController controller;
    public float gravity = 9.8f;
    Camera currentCamera;
    Vector3 cameraDir;
    bool isWalking;
    public AudioSource walkSFX;
    public AudioSource hurtSFX;
    //projectile shoot vars
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    /*//raycast shoot vars
    public Transform raycastPoint;
    Ray ray;*/

    Vector3 startPos;
    Animator anims;

    //temp var
    float dirY;
    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        anims = GetComponentInChildren<Animator>();
        startPos = transform.position;
        controller = GetComponent<CharacterController>();
        currentCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //handle jump and move
        Vector3 dir = currentCamera.transform.right * Input.GetAxis("Horizontal") + currentCamera.transform.forward * Input.GetAxis("Vertical");

        if(controller.isGrounded)
        {
            dirY = Input.GetAxis("Jump") * jumpHeight;
        }

        //move & jump
        dirY -= gravity * Time.deltaTime;
        dir.y = dirY;
        controller.Move(dir * Time.deltaTime * speed);
        //rotate
        cameraDir = currentCamera.transform.forward;
        cameraDir.y = 0;
        transform.LookAt(transform.position + cameraDir);


        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        /*else if (Input.GetMouseButtonDown(1))
        {
            Fire2();
        }*/
        if(dir.magnitude > 0.2)
        {
            if(!isWalking)
            {
                isWalking = true;
                walkSFX.Play();
            }
            anims.SetBool("isWalking", true);
        }
        else
        {
            isWalking = false;
            walkSFX.Stop();
            anims.SetBool("isWalking", false);
        }
    }

    void Fire()
    {
        spawnPoint.rotation = transform.rotation;
        Instantiate(projectilePrefab, spawnPoint);
    }

    /*void Fire2()
    {
        ray = new Ray(raycastPoint.transform.position, Vector3.forward);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyController>().PlayHurtEffect();
            }
        }
    }*/

    public void Respawn()
    {
        controller.enabled = false;
        transform.position = startPos;
        controller.enabled = true;
        hurtSFX.Play();
    }
}
