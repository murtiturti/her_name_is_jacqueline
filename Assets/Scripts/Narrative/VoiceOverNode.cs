using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    public class VoiceOverNode : NarrativeNode
    {
        public AudioClip voiceClip;

        private void OnTriggerEnter(Collider other)
        {
            StartChain();
        }

        public void SetNarratorVolume(float volumePct)
        {
            var volumeLvl = Math.Clamp(volumePct, 0f, 1f);
            narrator.SetVolume(volumeLvl);
        }

        public override void StartChain()
        {
            Link.LinkEvent?.Invoke();
            narrator.onVoiceLineEnd.AddListener(OnVoiceLineEnd);
            narrator.PlayVoiceLine(voiceClip);
        }

        private void OnVoiceLineEnd()
        {
            foreach (var chainLink in Link.ChainedNodes)
            {
                chainLink.StartChain();
            }
            narrator.onVoiceLineEnd?.RemoveListener(OnVoiceLineEnd);
        }
    }
}
