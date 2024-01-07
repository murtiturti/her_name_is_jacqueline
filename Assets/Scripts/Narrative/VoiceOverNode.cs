using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AriozoneGames.Narrative
{
    public class VoiceOverNode : NarrativeNode
    {
        public AudioClip voiceClip;

        private void OnTriggerEnter(Collider other)
        {
            narrator.PlayVoiceLine(voiceClip);
        }

        public void SetNarratorVolume(float volumePct)
        {
            var volumeLvl = Math.Clamp(volumePct, 0f, 1f);
            narrator.SetVolume(volumeLvl);
        }
    }
}
