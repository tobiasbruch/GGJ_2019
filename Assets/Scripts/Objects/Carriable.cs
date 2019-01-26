using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : Interactable
{
    public event Action<bool> EventIsCarriedChanged = delegate { };
    private bool _isCarried;
    public bool IsCarried
    {
        get { return _isCarried; }
        set
        {
            bool oldValue = _isCarried;
            _isCarried = value;
            if (oldValue != _isCarried)
            {
                EventIsCarriedChanged(_isCarried);
                OnIsCarriedChanged();
            }
        }
    }

    private Rigidbody _rigidbody;

    public bool IsKinematic
    {
        set
        {
            if (_rigidbody)
            {
                _rigidbody.isKinematic = value;
            }
        }
    }

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void OnIsCarriedChanged()
    {

    }
}
