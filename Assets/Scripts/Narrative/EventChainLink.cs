using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace AriozoneGames.Narrative
{
    public class EventChainLink : MonoBehaviour
    {
        public UnityEvent LinkEvent;
        public List<NarrativeNode> ChainedNodes;
    }
}
