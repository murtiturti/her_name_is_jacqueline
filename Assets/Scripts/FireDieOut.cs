using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireDieOut : MonoBehaviour
{
    public float duration;
    public UnityEvent dieOutEvent;

    [SerializeField] private ParticleSystem light;

    public void BlowOut()
    {
        StartCoroutine(Shrink());
    }
    
    private IEnumerator Shrink()
    {
        var elapsedTime = 0f;
        var currScale = transform.localScale;
        var targetScale = new Vector3(0.0002f, 0.0002f, 0.0002f);

        var lightsModule = light.lights;
        var currIntensity = lightsModule.intensityMultiplier;
        var targetIntensity = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(currScale, targetScale, elapsedTime / duration);
            lightsModule.intensityMultiplier = Mathf.Lerp(lightsModule.intensityMultiplier, 0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        dieOutEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
