using System;
using System.Collections;
using System.Collections.Generic;
using AriozoneGames.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Core
{
    public class NarrativeEventManager : MonoBehaviour
    {
        private Dictionary<string, NarrativeEvent> _eventDictionary;

        #region Singleton Pattern
        private static NarrativeEventManager _instance;
        public static NarrativeEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("NarrativeEventManager").AddComponent<NarrativeEventManager>();
                }

                return _instance;
            }
        }
        #endregion
        
        private void Awake()
        {
            if (_eventDictionary == null)
            {
                _eventDictionary = new Dictionary<string, NarrativeEvent>();
            }
        }

        public void TriggerEvent(NarrativeEvent narrativeEvent)
        {
            narrativeEvent.onTriggerEvent.Invoke();
        }

        public void TriggerEvent(string eventId)
        {
            if (_eventDictionary.TryGetValue(eventId, out var narrativeEvent))
            {
                narrativeEvent.onTriggerEvent.Invoke();
            }
        }

        public void AddEvent(string key, NarrativeEvent narrativeEvent)
        {
            _eventDictionary.TryAdd(key, narrativeEvent);
        }
    }
}
