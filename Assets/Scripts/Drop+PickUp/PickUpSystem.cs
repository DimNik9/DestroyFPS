using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer;

    public float pickUpRange, pickUpTime;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;


    [SerializeField] GameObject ammoText;
    [SerializeField] GameObject quickSlots;


    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) PickUp();
    }

    private void PickUp()
    {
        equipped = true;

        //Activate ammoText object when the first gun is equipped
        if (!ammoText.gameObject.activeSelf)
        {
            ammoText.SetActive(true);
        }
        //Send message at quickSlots objects, which handles the UI for the pick up system
        //Method GunPickUp will be called from quickSlots object
        quickSlots.SendMessage("GunPickUp", this.gameObject.name);
        this.gameObject.SetActive(false);
    }
}
