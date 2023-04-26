using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int selectedWeapon = 0;
    [SerializeField] GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            SelectWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();         
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.GetComponent<PickUpSystem>().equipped)
            {

                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                    weapon.GetComponent<ProjectileGun>().enabled = true;
                    Transform slot = inventory.transform.Find("Slot " + i);
                    Transform image = slot.Find("Image");
                    image.Find("Border").gameObject.SetActive(true);
                    
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                    weapon.GetComponent<ProjectileGun>().enabled = false;
                    Transform slot = inventory.transform.Find("Slot " + i);
                    Transform image = slot.Find("Image");
                    image.Find("Border").gameObject.SetActive(false);
                    
                }
                i++;
            }
        }
    }

}