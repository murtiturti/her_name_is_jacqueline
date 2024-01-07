using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Narrative
{
    public class NarrativeNode : MonoBehaviour
    {
        /*
         * Base class for narrative nodes, DON'T use instances
         */
        [SerializeField]
        private UnityEvent nodeEvent;
        [SerializeField]
        private UnityEvent prepEvent;
        public List<NarrativeNode> linkedNodes = new List<NarrativeNode>();

        public Narrator narrator;

        private void Start()
        {
            narrator = FindObjectOfType<Narrator>();
        }

        public void InvokeNodeEvent()
        {
            nodeEvent?.Invoke();
        }

        public void PrepNode()
        {
            prepEvent.Invoke();
        }
    }
}
