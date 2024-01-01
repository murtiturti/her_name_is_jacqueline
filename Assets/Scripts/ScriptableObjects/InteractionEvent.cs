using UnityEngine;

namespace AriozoneGames.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Interaction Event", menuName = "Events/Narrative/Interaction")]
    public class InteractionEvent: NarrativeEvent
    {
        public AudioClip voiceLine;
        private GameObject _interactObject;

        public void SetInteractObject(GameObject interactGo)
        {
            _interactObject = interactGo;
        }

        public GameObject GetInteractObject()
        {
            return _interactObject;
        }
    }
}