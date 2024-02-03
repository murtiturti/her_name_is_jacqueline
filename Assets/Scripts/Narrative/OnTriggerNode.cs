using System;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    [RequireComponent(typeof(Collider), typeof(EventChainLink))]
    public class OnTriggerNode: NarrativeNode
    {
        public override void StartChain()
        {
            RunChainedEvents();
        }

        private void OnTriggerEnter(Collider other)
        {
            Link.LinkEvent?.Invoke();
            StartChain();
        }
    }
}