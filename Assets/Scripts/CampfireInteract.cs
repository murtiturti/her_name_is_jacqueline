using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CampfireInteract : MonoBehaviour
{
    public UnityEvent inRange, lit, outOfRange;

    private bool _isLit;

    public Narrator narrator;
    public AudioClip voiceLine;

    private void Start()
    {
        narrator = FindObjectOfType<Narrator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isLit)
        {
            inRange?.Invoke();
            Debug.Log("Press E to sit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_isLit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lit.Invoke();
                _isLit = true;
                narrator.PlayVoiceLine(voiceLine);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outOfRange?.Invoke();
        }
    }
}
