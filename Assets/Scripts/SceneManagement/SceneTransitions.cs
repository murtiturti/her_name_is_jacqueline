using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AriozoneGames.SceneManagement
{
    public class SceneTransitions : MonoBehaviour
    {
        public void SwitchToMain()
        {
            Debug.Log("Should load scene");
            SceneManager.LoadScene(1);
        }

        public void SwitchToNight()
        {
            SceneManager.LoadScene(2);
        }

        public void SwitchToEnd()
        {
            SceneManager.LoadScene(3);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadMainMenuWithDelay(float delay)
        {
            StartCoroutine(LoadMenuWithDelay(delay));
        }

        private IEnumerator LoadMenuWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            LoadMainMenu();
        }
    }
}
