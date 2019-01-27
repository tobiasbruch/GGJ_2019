using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public Light Light;
    public AudioSource Audio;
    public AudioClip OffSound;
    public AudioClip OnSound;
    public override void OnInteractClick()
    {
        base.OnInteractClick();

        Audio.PlayOneShot(Light.enabled ? OffSound : OnSound);
        Light.enabled = !Light.enabled;

     
    }
}
