using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisCollider : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destructible")
        {
            playerObj.SendMessage("TakeDamage");
        }
    }
}
