using UnityEngine;
using UnityEngine.EventSystems;

public class Handkerchief : MonoBehaviour, IPointerClickHandler
{
    public bool hasHandkerchief = false;

    public void SetHandkerchief()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        hasHandkerchief = true;
        //gameObject.SetActive(false);
    }
}
