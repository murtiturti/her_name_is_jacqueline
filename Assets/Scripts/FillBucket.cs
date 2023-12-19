using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FillBucket : MonoBehaviour
{
    [SerializeField] private GameObject bucketWater;
    public UnityEvent inRangeEvent;
    public UnityEvent outOfRangeEvent;
    public UnityEvent filledUpEvent;

    private bool _bucketFilled = false;

    public Narrator narrator;
    public AudioClip voiceLine;

    private void Start()
    {
        narrator = FindObjectOfType<Narrator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_bucketFilled)
        {
            Debug.Log("Press E to fill bucket");
            inRangeEvent?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_bucketFilled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                narrator.PlayVoiceLine(voiceLine);
                bucketWater.SetActive(true);
                _bucketFilled = true;
                filledUpEvent.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outOfRangeEvent?.Invoke();
        }
    }
}
