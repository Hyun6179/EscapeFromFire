using UnityEngine;
using Oculus.Interaction;

public class FireExController : MonoBehaviour
{
    public ParticleSystem fireEx;
    
    public OVRInput.Controller RController = OVRInput.Controller.RTouch;
    public GameObject Model1; // 소화기 안든거.
    public GameObject Model2; // 소화기 든거

    private bool canActive = false;

    [SerializeField] private BoxCollider BoxC;
    [SerializeField] private BoxCollider BoxC2;

    private void Start()
    {
        Model1.gameObject.SetActive(true);
        Model2.gameObject.SetActive(false);

        BoxCollider[] boxes = gameObject.GetComponents<BoxCollider>();
        BoxC = boxes[0]; // 첫 번째 BoxCollider
        BoxC2 = boxes[1]; // 두 번째 BoxCollider
    }

    private void Update()
    {

        if (BoxC.enabled == false && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, RController))
        {
            Model1.gameObject.SetActive(false);
            Model2.gameObject.SetActive(true);
            canActive = true;
        }

        if (BoxC.enabled == true)
        {
            Model1.gameObject.SetActive(true);
            Model2.gameObject.SetActive(false);
            canActive = false;
        }

        if (canActive == true)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, RController))
            {
                fireEx.Play();
            }
            else
            {
                fireEx.Stop();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            BoxC.enabled = false;
            BoxC2.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            BoxC.enabled = true;
            BoxC2.enabled = true;
        }
    }
}
