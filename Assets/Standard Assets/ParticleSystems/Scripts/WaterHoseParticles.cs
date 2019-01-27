using System;
using UnityEngine;
using System.Collections.Generic;

namespace UnityStandardAssets.Effects
{
    public class WaterHoseParticles : MonoBehaviour
    {
        public static float lastSoundTime;
        public float force = 1;


        private List<ParticleCollisionEvent> m_CollisionEvents = new List<ParticleCollisionEvent>();
        private ParticleSystem m_ParticleSystem;


        private void Start()
        {
            m_ParticleSystem = GetComponent<ParticleSystem>();
        }


        private void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = m_ParticleSystem.GetCollisionEvents(other, m_CollisionEvents);
            int i = 0;
            
            while (i < numCollisionEvents)
            {

                Debug.Log(other.name);
                other.BroadcastMessage("AddLight", -.2f, SendMessageOptions.DontRequireReceiver);

                i++;
            }
        }
    }
}
