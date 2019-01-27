using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Speech : MonoBehaviour
{
    public static Speech Instance;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private AudioSource _voiceOver;

    private Sequence _sequence;

    public string Text
    {
        set
        {
            _text.text = value;
            if(_sequence != null)
            {
                _sequence.Kill();
            }
            _sequence = DOTween.Sequence();
            _sequence.Append(_canvasGroup.DOFade(1, .5f));
            _sequence.Append(_canvasGroup.DOFade(1, 3f));
            _sequence.Append(_canvasGroup.DOFade(0, 1f));
        }
    }

    public AudioClip AudioClip
    {
        set
        {
            _voiceOver.Stop();
            _voiceOver.clip = value;
            _voiceOver.loop = false;
            _voiceOver.Play();
        }
    }
    private void Awake()
    {
        Instance = this;
    }
}
