using System.Collections;
using UnityEngine;

namespace AriozoneGames.Effects
{
    public class AdjustLeafSpeed : MonoBehaviour
    {
        public float leafSpeed = 1f;
        public float speedUpDuration = 2f;

        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void IncreaseSpeed()
        {
            StartCoroutine(SpeedUpLeaves());
        }

        private IEnumerator SpeedUpLeaves()
        {
            ParticleSystem.Particle[] particles =
                new ParticleSystem.Particle[_particleSystem.particleCount];
            var particleCount =_particleSystem.GetParticles(particles);
            var speedUpTimer = 0f;
            for (int i = 0; i < particleCount; i++)
            {
                particles[i].velocity *= leafSpeed;
            }
            _particleSystem.SetParticles(particles);
            var emissionModule = _particleSystem.emission;
            emissionModule.rateOverTime = 50f;
            var mainModule = _particleSystem.main;
            mainModule.startSpeed = leafSpeed;
            while (speedUpTimer < speedUpDuration)
            {
                speedUpTimer += Time.deltaTime;
                yield return null;
            }

            mainModule.startSpeed = 1f;
            ParticleSystem.Particle[] newParticles =
                new ParticleSystem.Particle[_particleSystem.particleCount];
            particleCount = _particleSystem.GetParticles(newParticles);
            for (int i = 0; i < particleCount; i++)
            {
                newParticles[i].velocity /= leafSpeed;
            }
            _particleSystem.SetParticles(newParticles);
            emissionModule.rateOverTime = 5f;
        }
    }
}
