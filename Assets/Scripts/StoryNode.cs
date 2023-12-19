using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class StoryNode: MonoBehaviour
{
    [Header("Node Data")]
    public AudioClip voiceLine;
    [SerializeField] private List<GameObject> objectsToDeactivate;
    [SerializeField] private List<GameObject> objectsToActivate;
    public StoryNode next = null;
    [FormerlySerializedAs("_branching")] public bool branching = false;

    [SerializeField] private List<StoryNode> branchingNodes = new List<StoryNode>();
    
    public UnityEvent onThisNode;

    public Narrator narrator;

    private void Start()
    {
        narrator = FindObjectOfType<Narrator>();
    }

    public void Activate()
    {
        if (voiceLine != null)
        {
            narrator.PlayVoiceLine(voiceLine);
        }

        foreach (var obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        try
        {
            next.gameObject.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.Log("End of story chain or branching node");
        }

        if (branching)
        {
            try
            {
                foreach (var node in branchingNodes)
                {
                    node.gameObject.SetActive(true);
                }
            }
            catch (Exception e)
            {
                Debug.Log("End of story chain");
            }
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onThisNode?.Invoke();
        }
    }
}
