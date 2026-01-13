using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManage : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    private void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (fire1.gameObject.activeSelf == false &&  fire2.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
