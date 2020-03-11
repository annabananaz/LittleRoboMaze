using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera firstPersonCamera, thirdPersonCamera;

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
    }
}
