using UnityEngine;

namespace AriozoneGames.CustomEvents
{
    public class BucketDrop : MonoBehaviour
    {
        private AudioSource _impactSource;

        private void Start()
        {
            _impactSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 3)
            {
                _impactSource.Play();
            }
        }
    }
}
