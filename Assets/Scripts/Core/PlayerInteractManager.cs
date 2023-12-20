using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace AriozoneGames.Core
{
    public class PlayerInteractManager : MonoBehaviour
    {
        #region References
        private CinemachineBrain _cinemachineBrain;
        private Camera _playerCamera;
        #endregion

        #region RaycastVariables
        [SerializeField] private float range = 10f;
        #endregion

        #region InteractVariables
        private bool _isHandsFull = false;
        private bool _interactableSelected = false;
        private bool _isFrameOfSelection = false;
        #endregion
        
        // Start is called before the first frame update
        void Start()
        {
            _cinemachineBrain = FindObjectOfType<CinemachineBrain>();
            _playerCamera = _cinemachineBrain.OutputCamera;
        }

        // Update is called once per frame
        void Update()
        {
            var interactable = SelectInteractable();
            if (_interactableSelected)
            {
                if (_isFrameOfSelection)
                {
                    UIManager.Instance.ShowPrompt();
                    _isFrameOfSelection = false;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (CheckInteractConditions())
                    {
                        InteractWith(interactable);
                        UIManager.Instance.HidePrompt();
                    }
                }
            }
            else
            {
                UIManager.Instance.HidePrompt();
            }
        }

        private void InteractWith(IInteractable interactable)
        {
            interactable.Interact();
            if (interactable.InteractType == InteractType.Pickup)
            {
                _isHandsFull = true;
            }
        }


        private IInteractable SelectInteractable()
        {
            IInteractable go = null;
            var ray = _playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * range, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    go = interactable;
                    _interactableSelected = true;
                    if (!_isFrameOfSelection)
                    {
                        _isFrameOfSelection = true;
                    }
                    else
                    {
                        _isFrameOfSelection = false;
                    }
                }
                else
                {
                    _interactableSelected = false;
                }
            }
            else
            {
                _interactableSelected = false;
            }
            return go;
        }

        private bool CheckInteractConditions()
        {
            //TODO: Update this method to take the interact type and check conditions for each type
            return !_isHandsFull && _interactableSelected;
        }
        
    }
}
