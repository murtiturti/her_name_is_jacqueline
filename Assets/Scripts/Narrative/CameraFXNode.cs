using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace AriozoneGames.Narrative
{
    public class CameraFXNode : FXNode
    {
        [SerializeField]
        private GameObject cameraGameObject;

        [SerializeField]
        private bool turnOn;

        [SerializeField]
        private float blendDuration;
        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            if (turnOn)
            {
                cameraGameObject.SetActive(true);
            }
            else
            {
                cameraGameObject.SetActive(false);
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
