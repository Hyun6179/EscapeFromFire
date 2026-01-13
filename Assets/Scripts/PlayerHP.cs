using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private HPBar hpb;
    [SerializeField] private ToilWater ToilWater;

    public float GassDamage = 0.1f;
    public int RedDamage = 5;

    [SerializeField] private Transform vrCamera; // XR Origin 안의 Main Camera
    private float maxHeight = 0f;

    public bool isDamaged = false;

   
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

    public void GetDamage()
    {
        if (CanReceiveSmokeEvent() == true)
        {
            if (WashHandkerchief() == true)
            {
                hpb.getDamage(GassDamage / 10);
            }
            else hpb.getDamage(GassDamage);
        }
        else hpb.getDamage(GassDamage);
    }

    private bool CanReceiveSmokeEvent()
    {
        float currentHeight = vrCamera.localPosition.y;
        if (maxHeight <= 0f) return true; // 초기 안정화

        float ratio = currentHeight / maxHeight;
        return ratio >= 0.7f;
    }

    private bool WashHandkerchief()
    {
        if (ToilWater.hasWater)
            return true;

        return false;
    }

}
