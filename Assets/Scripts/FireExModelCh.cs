using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireExModelCh : MonoBehaviour
{
    public OVRInput.Controller RController = OVRInput.Controller.RTouch;
    public GameObject Model1; // 소화기 안든거.
    public GameObject Model2; // 소화기 든거

    private void Start()
    {
        Model1.gameObject.SetActive(true);
        Model2.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, RController))
        {
            Debug.Log("오른쪽 그랩");
            Model1.gameObject.SetActive(false);
            Model2.gameObject.SetActive(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, RController))
        {
            Debug.Log("오른쪽 그랩풀기");
            Model1.gameObject.SetActive(true);
            Model2.gameObject.SetActive(false);
        }
    }
}
