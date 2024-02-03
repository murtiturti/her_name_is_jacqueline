using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Effects
{
    public class FireDieOut : DefiniteFX
    {
        public UnityEvent dieOutEvent;

        [SerializeField] private ParticleSystem light;

        public void BlowOut()
        {
            StartCoroutine(Shrink());
        }

        public override void PlayFX()
        {
            BlowOut();
        }

        private IEnumerator Shrink()
        {
            var elapsedTime = 0f;
            var currScale = transform.localScale;
            var targetScale = new Vector3(0.0002f, 0.0002f, 0.0002f);

            var lightsModule = light.lights;
            var currIntensity = lightsModule.intensityMultiplier;
            var targetIntensity = 0f;

            while (elapsedTime < fxDuration)
            {
                transform.localScale = Vector3.Lerp(currScale, targetScale, elapsedTime / fxDuration);
                lightsModule.intensityMultiplier = Mathf.Lerp(lightsModule.intensityMultiplier, 0f, elapsedTime / fxDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            dieOutEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
