using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Narrative
{
    public abstract class NarrativeNode : MonoBehaviour
    {
        /*
         * Base class for narrative nodes, DON'T use instances
        */
        protected EventChainLink Link;
        public Narrator narrator;

        protected void Start()
        {
            narrator = FindObjectOfType<Narrator>();
            Link = GetComponent<EventChainLink>();
        }

        public abstract void StartChain();
    }
}
