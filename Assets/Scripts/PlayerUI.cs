using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject Bedroom;
    public GameObject Liv;
    public GameObject LivCollider;
    public GameObject RedDoor;
    public GameObject FireDead;
    public GameObject NoFire;

    public bool isReadUI;
    
    private void Start()
    {
        Bedroom.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LivCollider"))
        {
            Liv.SetActive(true);
            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("RedDoor"))
        {
            RedDoor.SetActive(true);
        }
    }


    private void Update()
    {
        if (Liv.activeSelf == true)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            isReadUI = true;
        }
        else
            isReadUI = false;

        if (FireDead.gameObject.activeSelf == false)
        {
            NoFire.SetActive(true);
        }
    }

}
