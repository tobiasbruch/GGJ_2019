using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memento : Carriable
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private MementoObject _mementoObject;
    public MementoObject MementoObject { get { return _mementoObject; } }

    protected override void Start()
    {
        base.Start();
    }

    public override void OnInteractClick()
    {
        base.OnInteractClick();
        PlayCue();
    }

    protected override void OnIsCarriedChanged()
    {
        base.OnIsCarriedChanged();

        if (IsCarried)
        {
            PlayCue();
        }
    }

    public void PlayCue()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.PlayOneShot(_mementoObject._audioCue);
    }
}
