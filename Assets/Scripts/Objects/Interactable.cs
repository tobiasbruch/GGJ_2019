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

    private QuickOutline _outline;

    protected virtual void Awake()
    {
        _outline = gameObject.AddComponent<QuickOutline>();

        _outline.OutlineMode = QuickOutline.Mode.OutlineAll;
        _outline.OutlineColor = Color.white;
        _outline.OutlineWidth = 7f;

        _outline.enabled = false;
    }

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
        _outline.enabled = true;

    }

    public void OnPointerExit()
    {
        _outline.enabled = false;

    }
}
