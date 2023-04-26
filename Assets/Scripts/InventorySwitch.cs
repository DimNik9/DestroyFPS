using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySwitch : MonoBehaviour
{

    private int availableSlots;
    [SerializeField] GameObject[] gunSlots;
    private bool[] IsSlotAvailable= new bool[5];

    [SerializeField] Sprite imageBlue;
    [SerializeField] Sprite imageBlack;
    [SerializeField] Sprite imageYellow;
    [SerializeField] Sprite imageWhite;
    [SerializeField] Sprite imageRed;


    [SerializeField] GameObject gunContainer;

    private GameObject currentGun = null;
    private GameObject prevGun = null;
    public int selectedWeapon = 0;




    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<5;i++)
        {
            IsSlotAvailable[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GunPickUp(string gunName)
    {
        availableSlots = FindAvailableSlot();
        IsSlotAvailable[availableSlots] = false;

        //Given the gunName, the corresponding image is activated
        //and moved in hierarchy based on the number of currently equipped guns
        if (gunName == "RedGun")
        {
            gunSlots[availableSlots].GetComponent<Image>().sprite = imageRed;
            gunSlots[availableSlots].SetActive(true);

        } 
        else if (gunName == "BlueGun") {
            gunSlots[availableSlots].GetComponent<Image>().sprite = imageBlue;
            gunSlots[availableSlots].SetActive(true);
        }
        else if (gunName == "YellowGun")
        {
            gunSlots[availableSlots].GetComponent<Image>().sprite = imageYellow;
            gunSlots[availableSlots].SetActive(true);
        }
        else if (gunName == "WhiteGun")
        {
            gunSlots[availableSlots].GetComponent<Image>().sprite = imageWhite;
            gunSlots[availableSlots].SetActive(true);
        }
        else if (gunName == "BlackGun")
        {
            gunSlots[availableSlots].GetComponent<Image>().sprite = imageBlack;
            gunSlots[availableSlots].SetActive(true);
        }

        gunContainer.transform.Find(gunName).GetComponent<PickUpSystem>().equipped = true;
        gunContainer.transform.Find(gunName).gameObject.SetActive(true);

        //Enable the last equipped gun and disable the previous one
        if (currentGun == null) {
            currentGun = gunContainer.transform.Find(gunName).gameObject;
            prevGun = currentGun;
        }
        else
        {
            prevGun.GetComponent<ProjectileGun>().enabled = false;
            prevGun.SetActive(false);
            currentGun = gunContainer.transform.Find(gunName).gameObject;
            prevGun = currentGun;
        }
        currentGun.transform.SetSiblingIndex(selectedWeapon);

        for (int y = 0; y < 5; y++)
        {
            Transform background = transform.Find("Slot " + y).transform.Find("Image").transform.Find("Border");
            if (background.gameObject.activeSelf)
            {
                background.gameObject.SetActive(false);
            }
        }

        transform.Find("Slot " + availableSlots).transform.Find("Image").transform.Find("Border").gameObject.SetActive(true);
        int prevSlot = availableSlots - 1;
        if (prevSlot >= 0)
        {
            transform.Find("Slot " + prevSlot).transform.Find("Image").transform.Find("Border").gameObject.SetActive(false);
        }
       
        selectedWeapon++;

    }

    public void GunDrop(string gunName)
    {
        int slot = FindSlotByName(gunName);
        gunSlots[slot].SetActive(false);
    }

    private int FindAvailableSlot()
    {
        for (int i=0;i<5;i++)
        {
            if (IsSlotAvailable[i] == true)
            {
                return i;
            }
            else continue;
        }
        return -1;
    }

    private int FindSlotByName(string gunName)
    {
        for (int i = 0; i < 5; i++)
        {
            if (gunName + " (UnityEngine.Sprite)" == gunSlots[i].GetComponent<Image>().sprite.ToString())
            {
                IsSlotAvailable[i] = true;         
                return i;
            }
        }
        return -1;
    }

}
