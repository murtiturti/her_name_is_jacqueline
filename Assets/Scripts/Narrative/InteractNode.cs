using System.Collections;
using System.Collections.Generic;
using AriozoneGames.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace AriozoneGames.Narrative
{
    public class InteractNode : NarrativeNode
    {
        public int[] toggleOnInteractionIds;
        public bool toggleValue;

        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            PlayerInteractManager.Instance.ToggleObjectsById(toggleOnInteractionIds, toggleValue);
            RunChainedEvents();
        }
    }
}
