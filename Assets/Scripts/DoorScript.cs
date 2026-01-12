using UnityEngine;

public class DoorAutoOpen : MonoBehaviour
{
    public Transform doorParent;   // 문 전체 오브젝트 (회전할 대상)
    public float openSpeed = 2f;   // 열리는 속도
    public float targetY = -90f;   // 최종 회전 각도
    private bool isOpening = false;
    private OVRInput.Controller RController = OVRInput.Controller.RTouch;

    private Quaternion startRotation;
    private Quaternion endRotation;

    void Start()
    {
        startRotation = doorParent.rotation;
        endRotation = Quaternion.Euler(doorParent.eulerAngles.x, targetY, doorParent.eulerAngles.z);
    }

    void Update()
    {
        if (isOpening)
        {
            doorParent.rotation = Quaternion.Lerp(doorParent.rotation, endRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Hand"))
        {
            if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, RController))
                isOpening = true;
        }
    }
}
