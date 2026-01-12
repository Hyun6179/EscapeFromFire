using UnityEngine;

public class SinkWater : MonoBehaviour
{
    [Header("Particle & Trigger")]
    public ParticleSystem waterParticle;   // 물줄기 파티클
    public Collider waterTrigger;          // Box Trigger 영역

    [Header("Fillable Object")]
    public string fillableTag = "Water";     // 물 채우기 대상 태그
    private bool isFilling = false;

    [Header("Fill Settings")]
    public float fillRate = 0.2f;          // 초당 채워지는 양
    private float fillAmount = 0f;
    public float maxFill = 1f;

    void Start()
    {
        if (waterTrigger != null)
            waterTrigger.isTrigger = true;

        if (waterParticle != null)
            waterParticle.Stop();
    }

    void Update()
    {
        // 수도꼭지 열리면 Particle Play
        //if () // 예시: VR 핸드의 트리거를 누르면 작동
        //{
        //    if (!waterParticle.isPlaying)
        //        waterParticle.Play();
        //}
        //else
        //{
        //    if (waterParticle.isPlaying)
        //        waterParticle.Stop();
        //}

        // 물 채우기
        if (isFilling)
        {
            fillAmount += fillRate * Time.deltaTime;
            fillAmount = Mathf.Min(fillAmount, maxFill);
            Debug.Log("Fill Amount: " + fillAmount);
        }
    }

}

