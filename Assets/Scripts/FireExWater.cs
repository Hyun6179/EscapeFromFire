using UnityEngine;
using System.Collections.Generic;

public class WaterParticleController : MonoBehaviour
{
    public ParticleSystem waterParticle;
    public List<Fire> fireScripts;

    private ParticleSystem.Particle[] particles;

    void Update()
    {
        int aliveCount = waterParticle.particleCount;

        if (particles == null || particles.Length < aliveCount)
            particles = new ParticleSystem.Particle[aliveCount];

        int count = waterParticle.GetParticles(particles);

        // 모든 Fire를 일단 꺼짐 상태로 초기화
        foreach (var fire in fireScripts)
        {
            fire.isExtinguishing = false;
        }

        // 각 파티클이 Fire Collider 안에 들어있는지 검사
        foreach (var fire in fireScripts)
        {
            Collider fireCollider = fire.GetComponent<Collider>();
            int insideCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (fireCollider.bounds.Contains(particles[i].position))
                {
                    insideCount++;
                }
            }

            if (insideCount > 0)
            {
                fire.isExtinguishing = true;
            }
        }
    }
}
