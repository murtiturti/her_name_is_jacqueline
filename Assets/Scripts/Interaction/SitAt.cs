using System;
using AriozoneGames.Core;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Interaction
{
    public class SitAt : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform sitPosition;
        [SerializeField] private GameObject toSit;
        public UnityEvent inRange, sitting, outOfRange;
        private bool _isSitting;

        public InteractType InteractType { get; set; }

        private void Start()
        {
            InteractType = InteractType.TranslatePlayer;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_isSitting)
            {
                inRange?.Invoke();
                Debug.Log("Press E to sit");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_isSitting)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    sitting.Invoke();
                    _isSitting = true;
                    toSit.transform.position = sitPosition.position;
                    toSit.transform.rotation = sitPosition.rotation;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                outOfRange?.Invoke();
            }
        }

        public void Interact()
        {
            sitting?.Invoke();
            _isSitting = true;
            toSit.transform.position = sitPosition.position;
            toSit.transform.rotation = sitPosition.rotation;
            var colliderTarget = GetComponent<BoxCollider>();
            colliderTarget.enabled = false;
        }
    }
}
