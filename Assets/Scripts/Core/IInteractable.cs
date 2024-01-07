using System.Collections;
using System.Collections.Generic;
using AriozoneGames.Narrative;
using AriozoneGames.ScriptableObjects;
using UnityEngine;

namespace AriozoneGames.Core
{
    public interface IInteractable
    {
        InteractType InteractType { get; set; }
        void Interact(); //TODO: Add parameter NarrativeNode
        bool IsInteractionEnabled { get; set; }
    }
}
