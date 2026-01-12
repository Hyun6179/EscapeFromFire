using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    public GameObject fire;
    public GameObject fire2;
    public GameObject startCanvas;
    public AudioSource Alarm;
    public bool hasFire = false;

    private void Start()
    {
        Alarm.mute = true;
    }

    void Update()
    {
        if (startCanvas.activeSelf == false && CheckFire() == true)
            Alarm.mute = false;
    }

    public void UnMute()
    {
        Alarm.mute = false;
    }

    private bool CheckFire()
    {
        if (fire.activeSelf == false && fire2.activeSelf == false)
            return true;
        else
            return false;
    }
}
