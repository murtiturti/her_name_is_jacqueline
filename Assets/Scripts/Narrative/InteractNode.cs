using System.Collections;
using System.Collections.Generic;
using AriozoneGames.Core;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    public class InteractNode : NarrativeNode
    {
        private IInteractable _interactable;

        new void Start()
        {
            base.Start();
            _interactable = GetComponent<IInteractable>();
        }
        
        public override void StartChain()
        {
            _interactable.Interact();
            //TODO: Implement the chain
        }
    }
}
