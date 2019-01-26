using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public bool Openable = true;
    public GameObject Collider;
    public Animator DoorAnimator;
    public AudioSource DoorSound;

    public override void OnInteractClick()
    {
        base.OnInteractClick();
       
        DoorSound.Play();

        if (!Openable)
            return;

        DoorAnimator.SetBool("openDoor", true);
        Invoke("DeactivateCollider", 0.2f);
    }

    void DeactivateCollider()
    {
        Collider.SetActive(false);
        Invoke("ActivateCollider", 1.0f);
    }

    void ActivateCollider()
    {
        Collider.SetActive(true);
    }
}
