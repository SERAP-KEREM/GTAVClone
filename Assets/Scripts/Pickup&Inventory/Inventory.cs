using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Item slots")]
    public GameObject Weapon1;
    public bool isWeapon1Picked = false;
    public bool isWeapon1Active = false;

    public GameObject Weapon2;
    public bool isWeapon2Picked = false;
    public bool isWeapon2Active = false;

    public GameObject Weapon3;
    public bool isWeapon3Picked = false;
    public bool isWeapon3Active = false;

    public GameObject Weapon4;
    public bool isWeapon4Picked = false;
    public bool isWeapon4Active = false;

    [Header("Weapons to Use")]
    public GameObject HandGun1;
    public GameObject HandGun2;
    public GameObject Shotgun;
    public GameObject UZI;
    public GameObject UZI2;
    public GameObject Bazooka;

    [Header("Scripts")]
    public PlayerScript playerScript;
    public Shotgun shotgunScript;
    public Handgun handgun1Script;
    public Handgun2 handgun2Script;
    public UZI uziScript;
    public UZI2 uzi2Script;
    public Bazooka bazooka;

    [Header("Inventory")]
    public GameObject inventoryPanel;
    bool isPause = false;

    public SwitchCamera switchCamera;
    public GameObject AimCam;
    public GameObject ThirdPersonCam;

    private void Update()
    {
        if (Input.GetKeyDown("1") && isWeapon1Picked == true)
        {
            isWeapon1Active = true;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = false;
            isRiflesActive();
        }
        else if (Input.GetKeyDown("2") && isWeapon2Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = true;
            isWeapon3Active = false;
            isWeapon4Active = false;
            isRiflesActive();

        }
        else if (Input.GetKeyDown("3") && isWeapon3Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = true;
            isWeapon4Active = false;
            isRiflesActive();

        }
        else if (Input.GetKeyDown("4") && isWeapon4Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = true;
            isRiflesActive();

        }
        else if (Input.GetKeyDown("tab"))
        {
            if (isPause)
            {
                hideInventory();
            }
            else
            {
                if(isWeapon1Picked==true)
                {
                    Weapon1.SetActive(true);    
                }
                if(isWeapon2Picked==true)
                {
                    Weapon2.SetActive(true);    
                }
                if(isWeapon3Picked==true)
                {
                    Weapon3.SetActive(true);    
                }
                if(isWeapon4Picked==true)
                {
                    Weapon4.SetActive(true);    
                }
               
                showInventory();
            }
        }
    }

    void isRiflesActive()
    {
        if (isWeapon1Active == true)
        {
            HandGun1.SetActive(true);
            HandGun2.SetActive(true);
            Shotgun.SetActive(false);
            UZI.SetActive(false);
            UZI2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotgunScript.GetComponent<Shotgun>().enabled = false;
            handgun1Script.GetComponent<Handgun>().enabled = true;
            handgun2Script.GetComponent<Handgun2>().enabled = true;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazooka.GetComponent<Bazooka>().enabled = false;
        }

        else if (isWeapon2Active == true)
        {
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            Shotgun.SetActive(true);
            UZI.SetActive(false);
            UZI2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotgunScript.GetComponent<Shotgun>().enabled = true;
            handgun1Script.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazooka.GetComponent<Bazooka>().enabled = false;
        }
        else if (isWeapon3Active == true)
        {
            Debug.Log("UZI aktif");
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            Shotgun.SetActive(false);
            UZI.SetActive(true);
            UZI2.SetActive(true);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotgunScript.GetComponent<Shotgun>().enabled = false;
            handgun1Script.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = true;
            uzi2Script.GetComponent<UZI2>().enabled = true;
            bazooka.GetComponent<Bazooka>().enabled = false;
        }

        else if (isWeapon4Active == true)
        {
            Debug.Log("Silah aktif");
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            Shotgun.SetActive(false);
            UZI.SetActive(false);
            UZI2.SetActive(false);
            Bazooka.SetActive(true);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotgunScript.GetComponent<Shotgun>().enabled = false;
            handgun1Script.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazooka.GetComponent<Bazooka>().enabled = true;
        }
    }
    void showInventory()
    {
        switchCamera.GetComponent<SwitchCamera>().enabled = false;
        ThirdPersonCam.SetActive(false);
        AimCam.SetActive(false);

        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    void hideInventory()
    {
        switchCamera.GetComponent<SwitchCamera>().enabled = true;
        ThirdPersonCam.SetActive(true);
        AimCam.SetActive(true);

        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }


}
