using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public HingeJoint doorHinge; // 문에 붙은 HingeJoint
    public float openForce = 5f; // 문을 열 때 힘

    private bool isGrabbed = false;

    void Update()
    {
        if (isGrabbed)
        {
            // hinge의 motor를 사용하여 문 회전
            JointMotor motor = doorHinge.motor;
            motor.targetVelocity = 100f; // 속도 값, 필요에 따라 조절
            motor.force = openForce;
            motor.freeSpin = false;
            doorHinge.motor = motor;
            doorHinge.useMotor = true;
        }
        else
        {
            doorHinge.useMotor = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            OnGrab();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            OnRelease();
        }
    }

    // 손잡이를 잡았을 때 호출
    public void OnGrab()
    {
        isGrabbed = true;
    }

    // 손을 놓았을 때 호출
    public void OnRelease()
    {
        isGrabbed = false;
    }
}
