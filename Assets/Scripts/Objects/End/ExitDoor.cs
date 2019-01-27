using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitDoor : Interactable
{
    [SerializeField]
    private Outro _outro;
    [SerializeField]
    private EndingObject[] _endings;
    [SerializeField]
    private EndingObject[] _badEndings;
    [SerializeField]
    private Box _box;

    public AudioSource Audio;
    public AudioClip SoundClipOpen;
    public AudioClip SoundClipClosed;

    public override void OnInteractClick()
    {
        base.OnInteractClick();
        if (!_box.IsCarried)
        {
            Audio.PlayOneShot(SoundClipClosed);
            Speech.Instance.Text = "I should grab the box before I leave";
        }
        else if (_box.Mementos.Length == 0)
        {
            Audio.PlayOneShot(SoundClipOpen);
            Speech.Instance.Text = "I should pack the box before I leave";
        }
        else
        {
            foreach (var ending in _endings)
            {
                if (EndingConditionsMet(ending))
                {
                    PlayEnding(ending);
                    return;
                }
            }
            PlayEnding(_badEndings[Random.Range(0, _badEndings.Length)]);
        }
    }

    private void PlayEnding(EndingObject ending)
    {
        if(ending._endingAudio != null)
        {
            float time = _box.Mementos[0].AudioSource.time;
            foreach (var item in _box.Mementos)
            {
                item.StopPlaying();
            }
            _box.Mementos[0].AudioSource.clip = ending._endingAudio;
            _box.Mementos[0].AudioSource.time = time;
            _box.Mementos[0].AudioSource.Play();

        }
        

        _outro.Ending = ending;
    }

    private bool EndingConditionsMet(EndingObject ending)
    {
        List<MementoObject> mementos = new List<MementoObject>();
        foreach (var item in _box.Mementos)
        {
            mementos.Add(item.MementoObject);
        }

        foreach (var item in ending._conditions)
        {
            if (!mementos.Remove(item))
            {
                return false;
            }
        }
        if (mementos.Count > 0)
            return false;

        return true;
    }
}
