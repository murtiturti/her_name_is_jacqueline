using UnityEngine.Events;

namespace AriozoneGames.Effects
{
    public class IndefiniteFX: EffectsBase
    {
        public UnityEvent onEventComplete;
        
        public override void PlayFX()
        {
            
        }

        public void RunOnComplete(UnityAction listener)
        {
            onEventComplete.AddListener(listener);
        }
    }
}