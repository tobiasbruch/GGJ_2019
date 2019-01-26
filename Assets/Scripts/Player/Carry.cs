using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    [SerializeField]
    private Transform _carrySlot;
    [SerializeField]
    private float _dropForce;

    private Carriable _currentlyCarried;

    // Start is called before the first frame update
    void Start()
    {
        FirstPersonRaycaster.Instance.EventCarryInteractable += OnCarryClicked;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (!FirstPersonRaycaster.Instance.CurrentInteractable && Input.GetButtonDown("Carry") && _currentlyCarried)
        {
            DropObject();
        }

    }

    private void OnCarryClicked(Interactable interactable)
    {
        Box box = interactable as Box;
        if (box != null && box.HasSpaceLeft && _currentlyCarried != null)
        {
            Memento memento = _currentlyCarried as Memento;
            if (memento)
            {
                DropObject();
                box.AddMemento(memento);
            }
        }
        else
        {
            Carriable carriable = interactable as Carriable;

            if (carriable != null)
            {
                if (_currentlyCarried == null)
                {
                    CarryObject(carriable);
                }
            }
        }
    }

    private void DropObject()
    {
        _currentlyCarried.transform.SetParent(null);
        _currentlyCarried.IsKinematic = false;
        Rigidbody rigidbody = _currentlyCarried.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddForce(_carrySlot.forward * _dropForce, ForceMode.Impulse);
        }
        _currentlyCarried.IsCarried = false;
        _currentlyCarried = null;
    }

    private void CarryObject(Carriable carriable)
    {
        _currentlyCarried = carriable;
        carriable.transform.SetParent(_carrySlot);
        _currentlyCarried.transform.localPosition = Vector3.zero;
        _currentlyCarried.transform.localRotation = Quaternion.identity;
        _currentlyCarried.IsKinematic = true;
        _currentlyCarried.IsCarried = true;
    }
}
