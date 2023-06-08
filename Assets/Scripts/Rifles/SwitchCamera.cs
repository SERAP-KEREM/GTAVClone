using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [Header("Camera to Assign")]
    public GameObject AimCam;
    public GameObject ThirdPersonCamera;
    public Animator animator;

    private void Update()
    {
        if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("AimWalk", true);
            animator.SetBool("ShootAim", false);

            ThirdPersonCamera.SetActive(false);
            AimCam.SetActive(true);

        }
        else if (Input.GetButton("Fire2"))
        {
            animator.SetBool("ShootAim", true);
            animator.SetBool("AimWalk", true);

            ThirdPersonCamera.SetActive(false);
            AimCam.SetActive(true);
        }
        else
        {
            animator.SetBool("AimWalk", false);
            animator.SetBool("ShootAim", false);

            ThirdPersonCamera.SetActive(true);
            AimCam.SetActive(false);
        }
    }
}
