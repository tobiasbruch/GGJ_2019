using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    public UnityAction _onInteractClicked = delegate { };
    [SerializeField]
    public UnityAction _onCarryClicked = delegate { };

    public virtual void OnCarryClick()
    {
        _onCarryClicked.Invoke();
    }

    public virtual void OnInteractClick()
    {
        _onInteractClicked.Invoke();
    }

    public void OnPointerEnter()
    {

    }

    public void OnPointerExit()
    {

    }
}
