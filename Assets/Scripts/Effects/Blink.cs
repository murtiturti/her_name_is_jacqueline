using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Effects
{
    public class Blink : MonoBehaviour
    {
        [SerializeField] private GameObject eyelidTop; // 2.3 to y=0.47
        [SerializeField] private GameObject eyelidBottom; // 0.73 to y=-0.47
        public float delayForBlink = 4f;
        public UnityEvent closeEvent, openEvent;

        private bool _blink = false;

        public void Close()
        {
            eyelidTop.SetActive(true);
            eyelidBottom.SetActive(true);
            StartCoroutine(CloseEyes());
        }

        public void Open()
        {
            StartCoroutine(OpenEyes());
        }

        private IEnumerator CloseEyes()
        {
            var delayTimer = 0f;
            while (delayTimer < delayForBlink)
            {
                delayTimer += Time.deltaTime;
                yield return null;
            }
            var targetTop = eyelidTop.transform.localPosition;
            targetTop.y = 0.47f;
            var targetBottom = eyelidBottom.transform.localPosition;
            targetBottom.y = -0.47f;
            while (Mathf.Abs(eyelidTop.transform.localPosition.y - targetTop.y) > 0.01f 
                   || Mathf.Abs(eyelidBottom.transform.localPosition.y - targetBottom.y) > 0.01f)
            {
                eyelidTop.transform.localPosition = Vector3.Lerp(eyelidTop.transform.localPosition, targetTop, 2f * Time.deltaTime);
                eyelidBottom.transform.localPosition =
                    Vector3.Lerp(eyelidBottom.transform.localPosition, targetBottom, 2f * Time.deltaTime);
                yield return null;
            }
            closeEvent?.Invoke();
        }

        private IEnumerator OpenEyes()
        {
            var delayTimer = 0f;
            while (delayTimer < delayForBlink)
            {
                delayTimer += Time.deltaTime;
                yield return null;
            }
            openEvent?.Invoke();
            var targetTop = eyelidTop.transform.localPosition;
            targetTop.y = 0.93f;
            var targetBottom = eyelidBottom.transform.localPosition;
            targetBottom.y = -0.645f;

            while (Mathf.Abs(eyelidTop.transform.localPosition.y - targetTop.y) > 0.01f 
                   || Mathf.Abs(eyelidBottom.transform.localPosition.y - targetBottom.y) > 0.01f)
            {
                eyelidTop.transform.localPosition =
                    Vector3.Lerp(eyelidTop.transform.localPosition, targetTop, 2f * Time.deltaTime);
                eyelidBottom.transform.localPosition = 
                    Vector3.Lerp(eyelidBottom.transform.localPosition, targetBottom, Time.deltaTime * 2f);
                yield return null;
            }
            eyelidTop.SetActive(false);
            eyelidBottom.SetActive(false);
            if (_blink)
            {
                closeEvent.RemoveListener(Open);
            }
        }

        public void BlinkEyes()
        {
            closeEvent.AddListener(Open);
            _blink = true;
            Close();
        }
    }
}
