using Unity.VisualScripting;
using UnityEngine;

public class ToilWater : MonoBehaviour
{
    public bool hasWater = false;
    [SerializeField] private Handkerchief hkc;

    private void OnTriggerEnter(Collider other)
    {
        if (hkc.hasHandkerchief)
        {
            hasWater = true;
        }
    }
}
