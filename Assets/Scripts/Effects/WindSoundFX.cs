using System.Collections;
using UnityEngine;

namespace AriozoneGames.Effects
{
    public class WindSoundFX : IndefiniteFX
    {
        private AudioSource _audioSource;

        public float oscillationFrequency;
        public float pitchAmplitude;
        public float maxPitch;

        private float _initialPitch;
        private float _elapsedTime = 0f;
    
        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _initialPitch = _audioSource.pitch;
        }

        public override void PlayFX()
        {
            WindFX();
        }

        public void WindFX()
        {
            StartCoroutine(OscillatePitch());
        }

        private IEnumerator OscillatePitch()
        {
            while (true)
            {
                var pitchOffset = Mathf.Sin(oscillationFrequency * _elapsedTime) * pitchAmplitude;
                _audioSource.pitch = Mathf.Clamp(_initialPitch + pitchOffset, _initialPitch - maxPitch, _initialPitch + maxPitch);
                _elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
