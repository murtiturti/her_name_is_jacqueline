using AriozoneGames.Core;
using AriozoneGames.Narrative;
using UnityEngine;

namespace AriozoneGames.Interaction
{
    public abstract class InteractableObject: MonoBehaviour
    {
        public InteractType InteractType;
        [SerializeField]
        protected bool IsInteractionEnabled;

        public int InteractId;

        public NarrativeNode chainNode;

        public void ToggleInteractability()
        {
            IsInteractionEnabled = !IsInteractionEnabled;
        }

        public void SetInteractability(bool canInteract)
        {
            IsInteractionEnabled = canInteract;
        }

        public bool IsInteractable()
        {
            return IsInteractionEnabled;
        }
    }
}