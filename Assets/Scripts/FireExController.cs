using UnityEngine;
using Oculus.Interaction;

public class FireExController : MonoBehaviour
{
    public ParticleSystem fireEx;
    public GameObject model2;
    public OVRInput.Controller Rcontrol = OVRInput.Controller.RTouch;
    private bool isPlaying = false;
    


    private void Update()
    {
        if (model2.activeSelf == true)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, Rcontrol))
            {
                fireEx.Play();
                isPlaying = true;
            }
            //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, Rcontrol)) 
            //{
            //    fireEx.Stop();
            //    isPlaying= false;
            //}
        }
    }
}
