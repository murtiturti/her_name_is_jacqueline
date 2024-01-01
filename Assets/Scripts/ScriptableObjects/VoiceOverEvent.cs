using UnityEngine;

namespace AriozoneGames.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Voice Over Event", menuName = "Events/Narrative/Voice Over")]
    public class VoiceOverEvent: NarrativeEvent
    {
        public AudioClip voiceLine;
    }
}