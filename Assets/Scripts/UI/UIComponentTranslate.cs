using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.UI
{
    public class UIComponentTranslate : MonoBehaviour
    {
        [SerializeField] private float delay = 0.5f;
        [SerializeField] private Vector2 translateDirection = Vector2.up;
        [SerializeField] private float speed = 1.5f;
        [SerializeField, Range(0f, 1f)] private float acceleration = 1f;

        private RectTransform _rectTransform;
        private Canvas _canvas;

        public UnityEvent gameStartEvent;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = _rectTransform.GetComponentInParent<Canvas>();
        }

        public void Translate()
        {
            StartCoroutine(TranslateUI());
        }

        private IEnumerator TranslateUI()
        {
            yield return new WaitForSeconds(delay);
            while (!IsOutOfBounds())
            {
                _rectTransform.anchoredPosition += translateDirection.normalized * speed;
                speed += acceleration;
                yield return null;
            }

            gameStartEvent.Invoke();
        }

        private bool IsOutOfBounds()
        {
            var canvasMinX = Remap(_canvas.pixelRect.xMin, 0f, Screen.width,  
                (float) -1 * Screen.width / 2, (float) Screen.width / 2);
            var canvasMaxX = Remap(_canvas.pixelRect.xMax, 0f, Screen.width,
                (float) -1 * Screen.width / 2, (float) Screen.width / 2);
            var canvasMinY = Remap(_canvas.pixelRect.yMin, 0f, Screen.height,
                (float) -1 * Screen.height / 2, (float) Screen.height / 2);
            var canvasMaxY = Remap(_canvas.pixelRect.yMax, 0f, Screen.height,
                (float) -1 * Screen.height / 2, (float) Screen.height / 2);
            if (translateDirection.x > 0)
            {
                if (_rectTransform.anchoredPosition.x - _rectTransform.rect.width < canvasMinX || 
                    _rectTransform.anchoredPosition.x + _rectTransform.rect.width > canvasMaxX)
                {
                    return true;
                }
            }

            if (translateDirection.y > 0)
            {
                if (_rectTransform.anchoredPosition.y + _rectTransform.rect.height < canvasMinY ||
                    _rectTransform.anchoredPosition.y - _rectTransform.rect.height > canvasMaxY)
                {
                    return true;
                }
            }
            return false;
        }

        private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return ((value - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin;
        }

    }
}
