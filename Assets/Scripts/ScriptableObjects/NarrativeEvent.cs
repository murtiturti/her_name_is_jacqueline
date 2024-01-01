using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Narrative Event", menuName = "Events/Narrative/Simple")]
    public class NarrativeEvent : ScriptableObject
    {
        public UnityEvent onTriggerEvent;
        public string eventId;
    }
}
