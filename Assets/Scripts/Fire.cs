using UnityEngine;
using System.Collections.Generic;

public class Fire : MonoBehaviour
{
    [Header("Fire Particle")]
    public ParticleSystem fireParticle;
    public float maxFireLife = 2.5f;
    public float IncreaseRate = 0.005f;  // 1초당 증가
    public Light fireLight;

    [Header("Smoke Particle")]
    public ParticleSystem smokeParticle;
    public float maxSmokeLife = 1f;

    [Header("GassSmoke Particle")]
    public ParticleSystem gassParticle;
    public float maxGassLife = 10f;

    [Header("Extinguish Settings")]
    public bool isExtinguishing = false;
    public float extinguishRate = 0.5f;

    private ParticleSystem.MainModule fireMain;
    private ParticleSystem.MainModule smokeMain;
    private ParticleSystem.MainModule gassMain;

    // 직접 수명 값 관리
    private float fireLife;
    private float gassLife;
    private float smokeLife;

    void Start()
    {
        fireMain = fireParticle.main;
        smokeMain = smokeParticle.main;
        gassMain = gassParticle.main;

        fireLife = fireMain.startLifetime.constant;
        gassLife = gassMain.startLifetime.constant;
        smokeLife = smokeMain.startLifetime.constant;

        if (fireLight != null)
            fireLight.intensity = fireLife;  // 초기 조명 세팅
        smokeParticle.Stop(); // 처음엔 연기 파티클 정지
    }

    void Update()
    {
        if (!isExtinguishing)
        {
            // 불 증가
            fireLife = Mathf.Min(fireLife + IncreaseRate * Time.deltaTime, maxFireLife);
            gassLife = Mathf.Min(gassLife + IncreaseRate * Time.deltaTime, maxGassLife);

            // Smoke는 불이 증가 중이면 정지
            if (smokeParticle.isPlaying)
                smokeParticle.Stop();
        }
        else
        {
            if (gassLife > 0)
            {
                // 불 감소
                fireLife = Mathf.Max(fireLife - extinguishRate * Time.deltaTime, 0);
                gassLife = Mathf.Max(gassLife - extinguishRate * Time.deltaTime, 0);
                smokeLife = fireLife;

                // Smoke 재생
                if (!smokeParticle.isPlaying)
                    smokeParticle.Play();
            }
            else
            {
                gameObject.SetActive(false);
                // Fire 완전히 꺼지면 Smoke도 정지
                if (smokeParticle.isPlaying)
                    smokeParticle.Stop();
            }
        }

        // 값 적용
        var fm = fireMain;
        fm.startLifetime = fireLife;
        fireMain = fm;

        var gm = gassMain;
        gm.startLifetime = gassLife;
        gassMain = gm;

        var sm = smokeMain;
        sm.startLifetime = smokeLife;
        smokeMain = sm;

        if (fireLight != null)
            fireLight.intensity = fireLife;

    }

}
