using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FirstPersonRaycaster : MonoBehaviour
{
    public static FirstPersonRaycaster Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.LogError("Cant have multiple instances of FirstPersonRaycaster");
            Destroy(gameObject);
        }
    }

    private Interactable _currentInteractable;

    public event Action<Interactable> EventPointerEnterInteractable = delegate { };
    public event Action<Interactable> EventPointerExitInteractable = delegate { };
    public event Action<Interactable> EventInteractInteractable = delegate { };
    public event Action<Interactable> EventCarryInteractable = delegate { };

    private void Update()
    {
        ProcessInput();
    }
    private void FixedUpdate()
    {
        Raycast();
    }

    private void ProcessInput()
    {
        if (_currentInteractable)
        {
            if (Input.GetButtonDown("Interact"))
            {
                EventInteractInteractable(_currentInteractable);
                _currentInteractable.OnInteractClick();
            }
            if (Input.GetButtonDown("Carry"))
            {
                EventCarryInteractable(_currentInteractable);
                _currentInteractable.OnCarryClick();
            }
        }
    }

    private void Raycast()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit))
        {
            var interactable = hit.collider.GetComponent<Interactable>();
            if (interactable)
            {
                if (interactable != _currentInteractable)
                {
                    if(_currentInteractable != null)
                    {

                        EventPointerExitInteractable(_currentInteractable);
                        _currentInteractable.OnPointerExit();
                        _currentInteractable = null;
                    }

                    _currentInteractable = interactable;
                    EventPointerEnterInteractable(_currentInteractable);
                    _currentInteractable.OnPointerEnter();
                }
            } else
            {
                if (_currentInteractable != null)
                {
                    EventPointerExitInteractable(_currentInteractable);
                    _currentInteractable.OnPointerExit();
                    _currentInteractable = null;
                }
            }
        }
    }
}
