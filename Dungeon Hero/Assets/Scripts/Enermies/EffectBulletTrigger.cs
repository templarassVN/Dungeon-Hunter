using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletTrigger : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }
    private void OnParticleTrigger()
    {
        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
 
        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter, out var enterData);
 
        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            if (enterData.GetColliderCount(i) == 1)
            {
                if (enterData.GetCollider(i, 0) == ps.trigger.GetCollider(0))
                    Debug.Log("hit");
            }

        }
    }
}
