using InteractableItems;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNameSpace
{
    public class InteractableController : MonoBehaviour 
    {
        [SerializeField]
        Camera playerCamera;

        [SerializeField]
        TextMeshProUGUI interactableText;

        [SerializeField]
        float interactbaleDistance = 5f;

        IInteractable currentTargetedInteractable;

        public void Update()
        {
            UpdateCurrentInteractable();

            UpdateInteractableText();

            CheckForInteractionInput();
        }

        void UpdateCurrentInteractable()
        {
            var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

            Physics.Raycast(ray, out var hit, interactbaleDistance);

            currentTargetedInteractable = hit.collider?.GetComponent<IInteractable>();

        }

        void UpdateInteractableText() {
            if (currentTargetedInteractable == null)
            {
                interactableText.text = string.Empty;
                return;
            }

            interactableText.text = currentTargetedInteractable.InteractableMessage;
        }
        
        void CheckForInteractionInput()
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && currentTargetedInteractable != null)
            {
                currentTargetedInteractable.Interact();
            }
        }
         
        }
    }
