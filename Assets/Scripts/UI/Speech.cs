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
    private void Awake()
    {
        Instance = this;
    }
}
