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
                // Show interaction prompt on frame of selection and toggle frame of selection
                if (_isFrameOfSelection)
                {
                    UIManager.Instance.ShowPrompt();
                    _isFrameOfSelection = false;
                }

                // if user pressed interact key
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Check conditions for interaction
                    if (CheckInteractConditions(interactable.InteractType))
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
            /*
             * Call the interact method of the object and set variables based on InteractType
             */
            interactable.Interact();
            if (interactable.InteractType == InteractType.Pickup)
            {
                _isHandsFull = true;
            }
        }


        private IInteractable SelectInteractable()
        {
            /*
             * Method for targeting an interactable GameObject. Returns the interactable component of the targeted
             * GameObject.
             */
            IInteractable go = null;
            // Cast ray of length var:range from center of camera position
            var ray = _playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * range, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                // Hit a collider
                var interactable = hit.collider.GetComponent<IInteractable>();
                // If the target is interactable
                if (interactable != null)
                {
                    go = interactable;
                    _interactableSelected = true;
                    // Decide if this is the frame of selection of the interactable object
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
                    // if target is not interactable
                    _interactableSelected = false;
                }
            }
            else
            {
                // if nothing was hit
                _interactableSelected = false;
            }
            return go;
        }

        private bool CheckInteractConditions(InteractType type)
        {
            //TODO: Update this method to take the interact type and check conditions for each type
            if (type == InteractType.Pickup)
            {
                return !_isHandsFull;
            }
            if (type == InteractType.Activate)
            {
                return _isHandsFull;
            }

            if (type == InteractType.TranslatePlayer)
            {
                return !_isHandsFull;
            }

            return false;
        }
        
    }
}
