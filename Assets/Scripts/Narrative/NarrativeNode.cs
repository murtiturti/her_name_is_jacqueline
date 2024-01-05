using System.Collections;
using System.Collections.Generic;
using AriozoneGames.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Narrative
{
    public class NarrativeNode : MonoBehaviour
    {
        public NarrativeEvent nodeEvent;
        public UnityEvent prepEvent;
        public List<NarrativeNode> linkedNodes = new List<NarrativeNode>();
    }
}
