using System;
using System.Collections;
using System.Collections.Generic;
using AriozoneGames.Narrative;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace AriozoneGames.Core
{
    public class NarrativeEventManager : MonoBehaviour
    {
        #region NodeData
            [SerializeField]
            private List<NarrativeNode> narrativeEventChains = new List<NarrativeNode>();
        #endregion
        
        #region Singleton Pattern
            private static NarrativeEventManager _instance;
            public static NarrativeEventManager Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<NarrativeEventManager>();
                        if (_instance == null)
                        {
                            GameObject go = new GameObject("NarrativeEventManager");
                            _instance = go.AddComponent<NarrativeEventManager>();
                        }
                    }

                    return _instance;
                }
            }
        #endregion

        private void Start()
        {

        }

        public void TriggerEvent(int index)
        {
            narrativeEventChains[index].StartChain();
        }

    }
}
