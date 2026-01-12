using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject L_Door;
    [SerializeField] private GameObject R_Door;

    [SerializeField] private Transform L_Open;
    [SerializeField] private Transform R_Open;
    [SerializeField] private Transform Stay;

    [SerializeField] private GameObject canvas;

    private float speed = 0.1f;
    private bool isOpen = false;

    private void Start()
    {
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (isOpen == true)
        {
            L_Door.transform.position = Vector3.MoveTowards(L_Door.transform.position, L_Open.position, speed * Time.deltaTime);
            R_Door.transform.position = Vector3.MoveTowards(R_Door.transform.position, R_Open.position, speed * Time.deltaTime);
            Player.transform.position = Stay.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("이벤트 영역 진입!");
            isOpen = true;
            canvas.SetActive(true);
        }
    }
}
