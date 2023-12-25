using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AriozoneGames.Core
{
    public interface IInteractable
    {
        InteractType InteractType { get; set; }
        void Interact();
        bool IsInteractionEnabled { get; set; }
    }
}
