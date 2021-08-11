using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Target;
    public float rotateSpeed = 10;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;*/
        //-1f * (mouseY * 180f)
        //transform.localRotation = Quaternion.Euler(new Vector4(30, mouseX * rotateSpeed, transform.localRotation.z));

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, Vector3.up) * offset;
        transform.position = Target.position + offset;
        transform.LookAt(Target);
    }
}


