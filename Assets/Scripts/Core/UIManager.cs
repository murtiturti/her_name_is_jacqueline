using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AriozoneGames.Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject mainMenuBackground;
        [SerializeField] private GameObject interactPrompt;
        [SerializeField] private Image fadeImage;
        [SerializeField] private GameObject pauseMenu;

        public float fadeDuration = 1f;

        public UnityEvent fadeOverEvent;
        public UnityEvent pauseEvent, resumeEvent;

        public bool _isPaused;

        [FormerlySerializedAs("_gameStarted")] public bool gameStarted = false;

        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<UIManager>();

                    if (FindObjectsOfType<UIManager>().Length > 1)
                    {
                        Debug.LogError("More than one instance of UIManager found");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(UIManager).Name);
                        _instance = singletonObject.AddComponent<UIManager>();
                    }
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Cursor.visible = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused && gameStarted)
            {
                Pause();
            }
        }

        public void DeactivateUI()
        {
            canvas.SetActive(false);
        }

        private void HideMenuBackground()
        {
            StartCoroutine(MenuBackgroundTransition());
        }

        public void OnGameStart()
        {
            HideMenuBackground();
            Cursor.visible = false;
        }

        public void ShowPrompt()
        {
            interactPrompt.SetActive(true);
        }

        public void HidePrompt()
        {
            interactPrompt.SetActive(false);
        }

        public void TogglePrompt()
        {
            if (interactPrompt.activeSelf)
            {
                interactPrompt.SetActive(false);
                return;
            }
            interactPrompt.SetActive(true);
        }

        public void Fade()
        {
            StartCoroutine(FadeToBlack());
        }

        private IEnumerator MenuBackgroundTransition()
        {
            var image = mainMenuBackground.GetComponent<Image>();
            var targetColor = image.color;
            targetColor.a = 0f;
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.1f)
            {
                var interpolatedColor = Color.Lerp(image.color, targetColor, Time.deltaTime * 5f);
                image.color = interpolatedColor;
                yield return null;
            }
            mainMenuBackground.SetActive(false);
            gameStarted = true;
        }

        private IEnumerator FadeToBlack()
        {
            float elapsedTime = 0f;
            Color startColor = fadeImage.color;
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

            while (elapsedTime < fadeDuration)
            {
                fadeImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the target color is set exactly
            fadeImage.color = targetColor;
            fadeOverEvent?.Invoke();
        }
    

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            _isPaused = true;
            pauseEvent?.Invoke();
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            _isPaused = false;
            resumeEvent?.Invoke();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void HideCursor()
        {
            Cursor.visible = false;
        }
    }
}
