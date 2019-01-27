using System.Collections;
using UnityEngine;

public class Memento : Carriable
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private MementoObject _mementoObject;
    public MementoObject MementoObject { get { return _mementoObject; } }

    private Coroutine _fadeOutRoutine;
    
    protected override void Start()
    {
        base.Start();
        AudioManagerStuff.i.RegisterMemento(this);
    }

    private void OnDestroy()
    {
        AudioManagerStuff.i.UnregisterMemento(this);
    }

    public override void OnInteractClick()
    {
        base.OnInteractClick();

        if (_audioSource.isPlaying && _fadeOutRoutine != null)
        {
            StopCoroutine(_fadeOutRoutine);
            _audioSource.Stop();
        }
        else
            PlayCuePreview();

        //AudioManagerStuff.i.StopAllMementosAudio();
    }

    protected override void OnIsCarriedChanged()
    {
        base.OnIsCarriedChanged();

        if (IsCarried)
        {
            AudioManagerStuff.i.StopAllMementosAudio();
            Play();
        } else
        {
            StopPlaying();
        }
    }

    public void PlayCuePreview()
    {
        if (_fadeOutRoutine != null)
            StopCoroutine(_fadeOutRoutine);
        _audioSource.volume = 1;

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.Play();
        

        _fadeOutRoutine = StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        while(_audioSource.volume > 0)
        {
            _audioSource.volume -= Time.deltaTime * .75f;
            yield return wait;
        }
        _audioSource.volume = 1;
        _audioSource.Stop();
    }

    public void Play()
    {
        if (_fadeOutRoutine != null)
            StopCoroutine(_fadeOutRoutine);
        _audioSource.volume = 1;

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.Play();
    }

    public void StopPlaying()
    {
        if (_fadeOutRoutine != null)
            StopCoroutine(_fadeOutRoutine);
        _audioSource.volume = 1;

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}
