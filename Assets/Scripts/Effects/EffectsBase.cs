using UnityEngine;

namespace AriozoneGames.Effects
{
    public abstract class EffectsBase: MonoBehaviour
    {
        public float fxStartDelay;

        public abstract void PlayFX();
    }
}