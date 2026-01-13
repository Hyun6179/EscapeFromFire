using System.Collections;
using UnityEngine;

public class OtherFire : MonoBehaviour
{
    private Fire fire;
    //[SerializeField] private LayerMask gassLayerMask;
    [SerializeField] private GameObject fireP;
    [SerializeField] private GameObject smokeP;
    [SerializeField] private GameObject gassP;
    //[SerializeField] private float growTime = 3f; // 불 붙는 시간

    //private bool isBurning = false;

    void Start()
    {
        fire = GetComponent<Fire>();
        fire.enabled = false;

        fireP.SetActive(false);
        smokeP.SetActive(false);
        gassP.SetActive(false);
    }

    public void IgniteFire(float growTime)
    {
        if (!fire.enabled)
        {
            StartCoroutine(StartFireGradually(growTime));
        }
    }


    private IEnumerator StartFireGradually(float growTime)
    {
        fire.enabled = true;
        fireP.SetActive(true);
        gassP.SetActive(true);

        float elapsed = 0f;
        var main = fireP.GetComponent<ParticleSystem>().main;
        float startSize = 0f;
        float targetSize = main.startSize.constant;

        // 파티클 크기 0 → 원래 크기까지 점점 증가
        while (elapsed < growTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / growTime;
            main.startSize = Mathf.Lerp(startSize, targetSize, t);
            yield return null;
        }

        main.startSize = targetSize; // 최종 크기 고정
    }
}
