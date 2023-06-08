using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{

    //Rifle movement var

    [Header("Player Movement")]
    public float playerSpeed = 1.1f;
    public float playerSprint = 5f;

    [Header("Player Animator & Gravity")]
    public CharacterController characterController;
    public float gravity = -9.81f;
    public Animator animator;

    [Header("Player Script Camera")]
    public Transform playerCamera;

    [Header("Player Jumping & Velocity")]
    public float jumpRange = 1f;
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;
    Vector3 velocity;
    public Transform surfaceCheck;
    bool onSurface;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;

    //Rifle shooting var

    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamage = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 10f;
    public float nextTimeToShoot = 0f;
    public Transform hand;
    public Transform PlayerTransform;
    public Handgun2 handgun2;
    public bool isMoving;

    [Header("Rifle Ammunition and reloding")]
    private int maximumAmmunition = 25;
    private int mag = 10;
    public int presentAmmunition;
    public float reloadingTime = 4.3f;
    private bool setReloading = false;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject metalEffect;
    public GameObject bloodEffect;

    [Header("Sounds & UI")]
    public GameObject AmmoOutUI;
    bool HandgunActive = true;

    private void Awake()
    {
        transform.SetParent(hand);
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmunition = maximumAmmunition;
    }

    private void Update()
    {
        if(HandgunActive==true)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("GunAnimator");
        }
        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistance, surfaceMask);

        if (onSurface && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);



        if (setReloading)
            return;

        if (presentAmmunition <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (isMoving == false)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
            {
                animator.SetBool("Shoot", true);
                nextTimeToShoot = Time.time + 1f / fireCharge;
                Shoot();
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }


        PlayerMove();
        Jump();
        Sprint();
    }
    void PlayerMove()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("WalkForward", true);
            animator.SetBool("RunForward", false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(PlayerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            PlayerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
            jumpRange = 0f;
            isMoving = true;
            handgun2.isMoving = true;
        }
        else
        {
            animator.SetBool("WalkForward", false);
            animator.SetBool("RunForward", false);
            jumpRange = 1f;
            isMoving = false;
            handgun2.isMoving = false;
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onSurface)
        {
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
        }
        else
        {
            animator.SetBool("IdleAim", true);
            animator.ResetTrigger("Jump");
        }
    }

    void Sprint()
    {
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && onSurface)
        {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

            if (direction.magnitude >= 0.1f)
            {
                Debug.Log("handgun walk");
                animator.SetBool("WalkForward", false);
                animator.SetBool("RunForward", true);

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(PlayerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
                PlayerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDirection.normalized * playerSprint * Time.deltaTime);
                jumpRange = 0f;
                isMoving = true;
                handgun2.isMoving = true;
            }
            else
            {
                animator.SetBool("WalkForward", true);
                animator.SetBool("RunForward", false);
                jumpRange = 1f;
                isMoving = false;
                handgun2.isMoving = false;
            }
        }
    }
    void Shoot()
    {
        if (mag == 0)
        {
            //show ammo out text/UI
            StartCoroutine(ShowAmmoOut());
            return;
        }

        presentAmmunition--;

        if (presentAmmunition == 0)
        {
            mag--;
        }
        //Update UI

        AmmoCount.instance.UpdateAmmoText(presentAmmunition);
        AmmoCount.instance.UpdateMagText(mag);



        muzzleSpark.Play();
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
           // Debug.Log(hitInfo.transform.name);

            Object obj = hitInfo.transform.GetComponent<Object>();
            PoliceOfficer policeOfficer=hitInfo.transform.GetComponent<PoliceOfficer>();
            CharacterNavigatorScript characterNavigatorScript=hitInfo.transform.GetComponent<CharacterNavigatorScript>();
            PoliceOfficer2 policeOfficer2 = hitInfo.transform.GetComponent<PoliceOfficer2>();
            FBIOfficer fBIOfficer = hitInfo.transform.GetComponent<FBIOfficer>();
            Gangster1 gangster1 = hitInfo.transform.GetComponent<Gangster1>();
            Gangster2 gangster2 = hitInfo.transform.GetComponent<Gangster2>();
            Boss boss= hitInfo.transform.GetComponent<Boss>();
            

            if (obj != null)
            {
                obj.objectHitDamage(giveDamage);
                GameObject metalEffectGo = Instantiate(metalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(metalEffectGo, 1f);
            }
            else if(policeOfficer!=null)
            {
                policeOfficer.characterHitDamage(giveDamage);
                GameObject bloodEffectGo=Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (characterNavigatorScript != null)
            {
                characterNavigatorScript.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (policeOfficer2 != null)
            {
                policeOfficer2.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (fBIOfficer != null)
            {
                fBIOfficer.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (gangster1 != null)
            {
                gangster1.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (gangster2 != null)
            {
                gangster2.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }
            else if (boss != null)
            {
                boss.characterHitDamage(giveDamage);
                GameObject bloodEffectGo = Instantiate(bloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodEffectGo, 1f);
            }

        }
    }
    IEnumerator Reload()
    {
        playerSpeed = 0f;
        playerSprint = 0f;
        setReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(reloadingTime);
        Debug.Log("Done reloading...");
        animator.SetBool("Reload", false);
        presentAmmunition = maximumAmmunition;
        playerSpeed = 1.1f;
        playerSprint = 5f;
        setReloading = false;
    }

    IEnumerator ShowAmmoOut()
    {
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
}
