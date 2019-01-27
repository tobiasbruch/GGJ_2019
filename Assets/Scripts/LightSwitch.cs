using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public Light Light;
    public AudioSource Audio;

    public override void OnInteractClick()
    {
        base.OnInteractClick();
        Light.enabled = !Light.enabled;
        Audio.Play();
    }
}
