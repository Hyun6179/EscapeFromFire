using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;

public class GassInteract : MonoBehaviour
{
    [SerializeField]private ParticleSystem gassParticle;
    private List<ParticleSystem.Particle> enterParticles = new List<ParticleSystem.Particle>();

    // Particle Trigger 모듈에서 이벤트가 발생하면 자동 호출됨
    private void OnParticleTrigger()
    {
        // Trigger 모듈에서 "Enter" 이벤트가 발생한 파티클들을 가져오기
        int enterCount = gassParticle.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);

        if (enterCount > 0)
        {
            Debug.Log("Gass 파티클이 OtherFire에 닿음! (" + enterCount + "개)");

            GameObject target = gassParticle.trigger.GetCollider(0).gameObject;
            OtherFire fireScript = target.GetComponent<OtherFire>();

            if (fireScript != null)
            {
                fireScript.IgniteFire(3f);
            }
        }
    }

    public float damageInterval = 1.0f;
    private float lastDamageTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            PlayerUI playerUI = other.GetComponent<PlayerUI>();

            if (playerUI.isReadUI == false)
            {
                if (Time.time >= lastDamageTime + damageInterval)
                {
                    if (playerHP != null)
                        playerHP.GetDamage();

                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
