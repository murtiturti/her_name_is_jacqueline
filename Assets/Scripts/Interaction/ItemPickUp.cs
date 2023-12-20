using AriozoneGames.Narrative;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Interaction
{
    public class ItemPickUp : MonoBehaviour
    {
        [SerializeField] private GameObject item;
        [SerializeField] private Transform parent;
        [SerializeField] private Transform positionWithinParent;

        private bool _pickedUp = false;

        private Rigidbody _bucketRigidbody;
        public UnityEvent inRangeEvent;
        public UnityEvent outOfRangeEvent;
        public UnityEvent pickedUpEvent;

        public AudioClip voiceLine;
        public Narrator narrator;

        private void Start()
        {
            _bucketRigidbody = item.GetComponent<Rigidbody>();
            narrator = FindObjectOfType<Narrator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                inRangeEvent?.Invoke();
                Debug.Log("Press E to pick up");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_pickedUp)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    narrator.PlayVoiceLine(voiceLine);
                    item.transform.parent = parent;
                    item.transform.position = positionWithinParent.position;
                    _bucketRigidbody.useGravity = false;
                    _bucketRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    item.transform.rotation = positionWithinParent.rotation;
                    var col = item.GetComponent<Collider>();
                    col.enabled = false;
                    _pickedUp = true;
                    pickedUpEvent?.Invoke();
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
