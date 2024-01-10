using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    public class CameraFXNode : NarrativeNode
    {
        [SerializeField]
        private GameObject cameraGameObject;

        [SerializeField]
        private bool turnOn;

        [SerializeField] 
        private float blendDuration;
        public override void StartChain()
        {
            if (turnOn)
            {
                cameraGameObject.SetActive(true);
            }

            StartCoroutine(Co_WaitForBlendEnd());
        }

        private IEnumerator Co_WaitForBlendEnd()
        {
            yield return new WaitForSeconds(blendDuration);
            RunChainedEvents();
        }
    }
}
