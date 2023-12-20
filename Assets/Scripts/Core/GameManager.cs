using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AriozoneGames.Core
{
    public class GameManager : MonoBehaviour
    {
        public UnityEvent gameStartEvent;
        [SerializeField] private GameObject jacquelineCamera;
        public float cameraDelay = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            gameStartEvent?.Invoke();
            Time.timeScale = 1f;
        }

        public void SwitchToPlayerCamera()
        {
            StartCoroutine(WaitAndSwitch());
        }

        private IEnumerator WaitAndSwitch()
        {
            yield return new WaitForSeconds(cameraDelay);
            jacquelineCamera.SetActive(false);
        }
    
    }
}
