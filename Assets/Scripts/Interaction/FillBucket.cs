using AriozoneGames.Core;
using AriozoneGames.Narrative;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Interaction
{
    public class FillBucket : InteractableObject, IInteractable
    {
        [SerializeField] private GameObject bucketWater;
        public UnityEvent inRangeEvent;
        public UnityEvent outOfRangeEvent;
        public UnityEvent filledUpEvent;

        private bool _bucketFilled = false;

        public Narrator narrator;
        public AudioClip voiceLine;

        private void Start()
        {
            narrator = FindObjectOfType<Narrator>();
            InteractType = InteractType.Activate;
            IsInteractionEnabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_bucketFilled)
            {
                Debug.Log("Press E to fill bucket");
                inRangeEvent?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_bucketFilled)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    narrator.PlayVoiceLine(voiceLine);
                    bucketWater.SetActive(true);
                    _bucketFilled = true;
                    filledUpEvent.Invoke();
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

        public void Interact()
        {
            if (voiceLine != null)
            {
                narrator.PlayVoiceLine(voiceLine);
            }
            bucketWater.SetActive(true);
            _bucketFilled = true;
            filledUpEvent?.Invoke();
        }
    }
}
