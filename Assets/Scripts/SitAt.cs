using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SitAt : MonoBehaviour
{
    [SerializeField] private Transform sitPosition;
    [SerializeField] private GameObject toSit;
    public UnityEvent inRange, sitting, outOfRange;
    private bool _isSitting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isSitting)
        {
            inRange?.Invoke();
            Debug.Log("Press E to sit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_isSitting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sitting.Invoke();
                _isSitting = true;
                toSit.transform.position = sitPosition.position;
                toSit.transform.rotation = sitPosition.rotation;
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
