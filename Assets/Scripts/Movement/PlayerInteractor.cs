using Input;
using Kitchen.Base;
using UI;
using UnityEngine;

namespace Movement
{
    public class PlayerInteractor : MonoBehaviour
    {
        [Header("Dependencies")] [SerializeField]
        private Transform playerCamera;

        [SerializeField] private InputObject inputObject;

        [Header("Settings")] [SerializeField] private float maxDistance = 2f;
        [SerializeField] private LayerMask interactableLayer;

        private bool _isInteracting;
        private bool _hasInteracted;

        private void Start()
        {
            inputObject.InteractEvent += OnInteract;
            inputObject.InteractCanceledEvent += OnInteractCanceled;
        }

        private void FixedUpdate()
        {
            if (_isInteracting || Debug.isDebugBuild)
            {
                DrawRay();
            }

            if (_isInteracting)
            {
                Interact();
            }
        }

        private void Interact()
        {
            if (_hasInteracted) return; // If interaction has already occurred, return

            Ray r = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit[] hits = new RaycastHit[10]; // Allocate an array to store the results
            int numHits = Physics.RaycastNonAlloc(r, hits, maxDistance);

            for (int i = 0; i < numHits; i++)
            {
                RaycastHit hit = hits[i];
                if (interactableLayer == (interactableLayer | (1 << hit.collider.gameObject.layer)))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
                    {
                        interactableObj.Interact();
                        _hasInteracted = true; // Set _hasInteracted to true after interaction
                        break; // Stop after interacting with the first interactable object
                    }
                }
            }
        }

        private void DrawRay()
        {
            Ray r = new Ray(playerCamera.position, playerCamera.forward);
            Debug.DrawRay(r.origin, r.direction * maxDistance, Color.red);
        }

        #region Events

        private void OnInteractCanceled()
        {
            _isInteracting = false;
            _hasInteracted = false; // Reset _hasInteracted when interaction is canceled
        }

        private void OnInteract()
        {
            _isInteracting = true;
        }

        #endregion
    }
}
