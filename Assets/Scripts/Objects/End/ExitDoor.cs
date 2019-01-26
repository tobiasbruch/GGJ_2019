using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitDoor : Interactable
{
    [SerializeField]
    private EndingObject[] _endings;
    [SerializeField]
    private EndingObject[] _badEndings;
    [SerializeField]
    private Box _box;

    public override void OnInteractClick()
    {
        base.OnInteractClick();
        if (!_box.IsCarried)
        {
            Debug.Log("You need to bring the box");
        }
        else if (_box.HasSpaceLeft)
        {
            Debug.Log("You need to collect more items");
        } else
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
        Debug.Log(ending._endingText);
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
        return true;
    }
}
