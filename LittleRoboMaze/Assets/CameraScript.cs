using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera firstPersonCamera, thirdPersonCamera;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCamera.MoveToTopOfPrioritySubqueue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            firstPersonCamera.MoveToTopOfPrioritySubqueue();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            thirdPersonCamera.MoveToTopOfPrioritySubqueue();
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            thirdPersonCamera.transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Period))
        {
            thirdPersonCamera.transform.RotateAround(transform.parent.position, new Vector3(0, -1, 0), rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            thirdPersonCamera.transform.position = transform.parent.position + new Vector3(-6, 4, -2);
            thirdPersonCamera.transform.LookAt(transform.parent);
        }
    }
}
