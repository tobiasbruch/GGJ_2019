using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public GameObject Collider;
    public Animator DoorAnimator;
    public override void OnInteractClick()
    {
        base.OnInteractClick();
        DoorAnimator.SetBool("openDoor", true);
        Invoke("DeactivateCollider", 1f);
    }

    void DeactivateCollider()
    {
        Collider.SetActive(false);
    }
}
