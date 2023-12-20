using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Narrative
{
    public class Narrator : MonoBehaviour
    {
        private AudioSource _source;
        public UnityEvent onVoiceLineEnd;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        public void PlayVoiceLine(AudioClip clip)
        {
            _source.Stop();

            _source.clip = clip;
            _source.Play();

            StartCoroutine(CheckAudioStatus());
        }
    

        private IEnumerator CheckAudioStatus()
        {
            yield return new WaitForSeconds(_source.clip.length);
            onVoiceLineEnd?.Invoke();
        }
    
    }
}
