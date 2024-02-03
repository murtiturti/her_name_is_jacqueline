using AriozoneGames.Core;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace AriozoneGames.Interaction
{
    public class WaterJacqueline : InteractableObject, IInteractable
    {
        public UnityEvent wateredEvent;
        public GameObject bucket;
        private Rigidbody _bucketRb;
        private bool _watered = false;
        

        private void Start()
        {
            InteractType = InteractType.StoryAdvance;
            IsInteractionEnabled = false;
            _bucketRb = bucket.GetComponent<Rigidbody>();
        }

        public void Interact()
        {
            wateredEvent?.Invoke();
            _watered = true;
            _bucketRb.constraints = RigidbodyConstraints.None;
            bucket.transform.parent = null;
            _bucketRb.AddForce(new Vector3(Random.Range(0.3f, 1f), Random.Range(3f, 7.5f), Random.Range(0.3f, 1f)));
            _bucketRb.AddTorque(new Vector3(0f, 0f, Random.Range(0.5f, 1.5f)));
        }
    }
}
