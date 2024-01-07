using System;
using System.Collections;
using System.Collections.Generic;
using AriozoneGames.Narrative;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Core
{
    public class NarrativeEventManager : MonoBehaviour
    {
        #region NodeData
            [SerializeField]
            private List<NarrativeNode> narrativeEventChain = new List<NarrativeNode>();
            private NarrativeNode _currentNode;
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
            _currentNode = narrativeEventChain[0];
        }

        public void TriggerEvent(NarrativeNode narrativeNode)
        {
            narrativeNode.InvokeNodeEvent();
            _currentNode = narrativeNode;
            SetUpNextNodes();
        }


        private void SetUpNextNodes()
        {
            var nextNodes = _currentNode.linkedNodes;
            foreach (var node in nextNodes)
            {
                node.PrepNode();
            }
        }
    }
}
