using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Carriable
{
    [SerializeField]
    private int _capacity = 3;
    [SerializeField]
    private Transform[] _slots;

    public bool HasSpaceLeft {
        get
        {
            var count = 0;
            foreach (var item in _slots)
            {
                count += item.childCount;
            }
            return count < _capacity;
        }
    }

    public Memento[] Mementos
    {
        get
        {
            return GetComponentsInChildren<Memento>();
        }
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnIsCarriedChanged()
    {
        base.OnIsCarriedChanged();
        if (IsCarried)
        {
            foreach (var item in Mementos)
            {
                item.Play();
            }
        }
        else
        {
            foreach (var item in Mementos)
            {
                item.StopPlaying();
            }
        }
    }
    public override void OnInteractClick()
    {
        base.OnInteractClick();
        PlayMusicPreview();
    }

    private void PlayMusicPreview()
    {
        foreach (var item in Mementos)
        {
            item.PlayCuePreview();
        }
    }

    public void AddMemento(Memento memento)
    {
        foreach (var slot in _slots)
        {
            if(slot.childCount == 0)
            {
                memento.transform.SetParent(slot);
                break;
            }
        }

        memento.transform.localPosition = Vector3.zero;
        memento.transform.localRotation = Quaternion.identity;
        memento.IsKinematic = true;
    }
}
