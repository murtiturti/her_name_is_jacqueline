using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace AriozoneGames.Interaction
{
    public class WaterJacqueline : MonoBehaviour
    {
        public UnityEvent inRangeEvent, outOfRangeEvent, wateredEvent;
        public GameObject bucket;
        private Rigidbody _bucketRb;
        private bool _watered = false;

        private void Start()
        {
            _bucketRb = bucket.GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_watered)
            {
                inRangeEvent?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_watered)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    wateredEvent?.Invoke();
                    _watered = true;
                    _bucketRb.constraints = RigidbodyConstraints.None;
                    bucket.transform.parent = null;
                    _bucketRb.AddForce(new Vector3(Random.Range(0.3f, 1f), Random.Range(0.3f, 2f), Random.Range(0.3f, 1f)));
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                outOfRangeEvent?.Invoke();
            }
        }
    }
}
