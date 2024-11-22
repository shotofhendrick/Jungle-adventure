using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weapons : MonoBehaviour
{

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public bool weapon1Obtain;
    public bool weapon2Obtain;
    public bool weapon3Obtain;
    public weaponstate currentWeapon;
    
    public void Update()
    {
        //FindAnyObjectByType<weapons>().AcquireWeapon(weaponstate.weapon1);

        // Check if the user presses 1, 2, or 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(weaponstate.weapon1);
            Debug.Log("pressed1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(weaponstate.weapon2);
            Debug.Log("pressed2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(weaponstate.weapon3);
            Debug.Log("pressed3");
        }

    }
    public void AcquireWeapon(weaponstate state)
    {
        switch (state)
        {
            case weaponstate.weapon1:
                weapon1Obtain = true;
                break;
            
            case weaponstate.weapon2:
                weapon2Obtain = true;
                break;

            case weaponstate.weapon3:
                weapon3Obtain = true;
                break;
        }
    }
    public void ChangeWeapon(weaponstate state)
    {
        switch (state)
        {
            case weaponstate.weapon1:
                if (weapon1Obtain)
                {
                    weapon1.SetActive(true);
                    weapon2.SetActive(false);
                    weapon3.SetActive(false);
                    currentWeapon = weaponstate.weapon1;
                }
                break;

            case weaponstate.weapon2:
                if (weapon2Obtain)
                {
                    weapon1.SetActive(false);
                    weapon2.SetActive(true);
                    weapon3.SetActive(false);
                    currentWeapon = weaponstate.weapon2;
                }
                break;

            case weaponstate.weapon3:
                if (weapon3Obtain)
                {
                    weapon1.SetActive(false);
                    weapon2.SetActive(false);
                    weapon3.SetActive(true);
                    currentWeapon = weaponstate.weapon3;
                }
                break;
        }
    }
  
}


public enum weaponstate
{
    weapon1, weapon2, weapon3
}