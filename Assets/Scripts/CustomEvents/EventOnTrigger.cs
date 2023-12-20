using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.CustomEvents
{
    public class EventOnTrigger : MonoBehaviour
    {

        public UnityEvent onTriggerEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onTriggerEvent?.Invoke();
            }
        }
    }
}
