using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private HPBar hpb;
    [SerializeField] private ToilWater ToilWater;

    public float GassDamage = 10f;
    public int RedDamage = 5;

    [SerializeField] private Transform vrCamera; // XR Origin 안의 Main Camera
    private float maxHeight = 0f;

    public bool isDamaged = false;
    private float damageTime = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer mesh = other.GetComponent<MeshRenderer>();
        if (mesh != null && mesh.materials.Length > 1)
        {
            if (mesh.materials[1].Equals("Red"))
            {
                hpb.getDamage(RedDamage);
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Gass"))
    //    {
    //        if (Time.time > 5 * damageTime * Time.deltaTime)
    //        {
    //            GetDamage();
    //            damageTime = Time.time;
    //        }
    //    }
    //}

    public void GetDamage()
    {
        if (CanReceiveSmokeEvent() == true)
        {
            //if (WashHandkerchief() == true)
            //{
            //    hpb.getDamage(GassDamage / 10);
            //}
            //else
            hpb.getDamage(GassDamage / 5);
        }
        else
            hpb.getDamage(GassDamage);
    }

    private bool CanReceiveSmokeEvent()
    {
        float currentHeight = vrCamera.localPosition.y;
        if (maxHeight <= 0f) return false; // 초기 안정화

        float ratio = currentHeight / maxHeight;
        return ratio < 0.7f;
    }

    private bool WashHandkerchief()
    {
        if (ToilWater.hasWater)
            return true;

        return false;
    }

}
