using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Image _image;
    public float fadeInDuration;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void FadeImageIn()
    {
        StartCoroutine(IncreaseAlpha());
    }

    private IEnumerator IncreaseAlpha()
    {
        float elapsedTime = 0f;
        Color startColor = _image.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < fadeInDuration)
        {
            _image.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the target color is set exactly
        _image.color = targetColor;
    }
}
