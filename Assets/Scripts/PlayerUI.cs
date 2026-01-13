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

    public Transform Player;
    public bool isReadUI;
    
    private void Start()
    {
        Bedroom.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == LivCollider)
        {
            Liv.SetActive(true);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject == RedDoor)
        {
            RedDoor.SetActive(true);
        }
    }

    private void Update()
    {
        if (Liv.activeSelf == true)
        {
            transform.position = Player.position;
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
