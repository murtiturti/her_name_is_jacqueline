using System.Collections;
using AriozoneGames.Effects;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    public class FXNode: NarrativeNode
    {
        [SerializeField] private DefiniteFX definiteFx;
        [SerializeField] private IndefiniteFX indefiniteFx;

        [SerializeField] private bool isIndefiniteFx;
        
        public override void StartChain()
        {
            if (!isIndefiniteFx)
            {
                StartCoroutine(WaitUntilFXEnd());
            }
            else
            {
                StartCoroutine(WaitForDelay());
            }
        }

        private IEnumerator WaitUntilFXEnd()
        {
            yield return new WaitForSeconds(definiteFx.fxStartDelay);
            Link.LinkEvent?.Invoke();
            definiteFx.PlayFX();
            yield return new WaitForSeconds(definiteFx.fxDuration);
            RunChainedEvents();
        }

        private IEnumerator WaitForDelay()
        {
            yield return new WaitForSeconds(indefiniteFx.fxStartDelay);
            indefiniteFx.RunOnComplete(RunChainedEvents);
            Link.LinkEvent?.Invoke();
            indefiniteFx.PlayFX();
        }
    }
}