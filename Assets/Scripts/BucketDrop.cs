using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BucketDrop : MonoBehaviour
{
    private AudioSource _impactSource;

    private void Start()
    {
        _impactSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            _impactSource.Play();
        }
    }
}
