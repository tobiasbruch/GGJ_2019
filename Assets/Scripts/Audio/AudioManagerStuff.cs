using System;
using UnityEngine;

public class AudioManagerStuff : MonoBehaviour
{
    public static AudioManagerStuff i;

    private Action TurnOffAllMementos;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
    }

    public void RegisterMemento(Memento memento)
    {
        TurnOffAllMementos += memento.StopPlaying;
    }

    public void UnregisterMemento(Memento memento)
    {
        TurnOffAllMementos -= memento.StopPlaying;
    }

    public void StopAllMementosAudio()
    {
        TurnOffAllMementos();
    }

}
