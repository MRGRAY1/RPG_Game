using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float interactionDistance;

    [SerializeField]
    private GameObject PickUp_Obj;

    private MainInput controls;

    private readonly string[] interactableTags = { "SInteractable", "PInteractable" };

    private void Awake()
    {
        controls = new MainInput();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.PlayerMovement.Interact.performed += OnInteract;
        controls.PlayerMovement.Drop.performed += OnDrop;
    }

    private void OnDisable()
    {
        controls.PlayerMovement.Interact.performed -= OnInteract;
        controls.PlayerMovement.Drop.performed -= OnDrop;
        controls.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Logger.EventLog("Interact");
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            foreach (var tag in interactableTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    var interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}