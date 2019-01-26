using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{


    [SerializeField]
    private Animator _crosshairAnimator;

    // Start is called before the first frame update
    void Start()
    {
        FirstPersonRaycaster.Instance.EventPointerEnterInteractable += OnPointerEnterInteractable;
        FirstPersonRaycaster.Instance.EventPointerExitInteractable += OnPointerExitInteractable;
    }

    private void OnPointerEnterInteractable(Interactable interactable)
    {
        _crosshairAnimator.SetBool("PointerOverInteractable", true);
    }

    private void OnPointerExitInteractable(Interactable interactable)
    {
        _crosshairAnimator.SetBool("PointerOverInteractable", false);
    }
}
