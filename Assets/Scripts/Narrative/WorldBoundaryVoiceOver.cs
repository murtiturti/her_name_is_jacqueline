using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AriozoneGames.Narrative
{
    public class WorldBoundaryVoiceOver : MonoBehaviour
    {

        [SerializeField] private List<AudioClip> clips = new List<AudioClip>();

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.clip = clips[Random.Range(0, clips.Count)];
                    _audioSource.Play();
                }
            }
        }
    }
}
