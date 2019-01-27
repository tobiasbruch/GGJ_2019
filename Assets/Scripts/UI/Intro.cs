using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _backgroundNoises;
    [SerializeField]
    private AudioClip _narration;
    [SerializeField]
    private FirstPersonController _player;

    private Animator _animator;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _player.enabled = false;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger("IntroState", 0);
    }

    public void StartIntro()
    {
        StartCoroutine(IntroRoutine());
    }

    public void StartGame()
    {
        _animator.SetInteger("IntroState", 3);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _player.enabled = true;
    }

    IEnumerator IntroRoutine()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        yield return wait;
        _animator.SetInteger("IntroState", 1);
        if (_backgroundNoises)
        {
            _audioSource.clip = _backgroundNoises;
            _audioSource.loop = false;
            _audioSource.Play();
            yield return new WaitWhile(()=> { return _audioSource.isPlaying || !Input.GetMouseButtonDown(0); });
        }  else
        {
            yield return new WaitForSeconds(.5f);
        }

        _animator.SetInteger("IntroState", 2);
        yield return wait;

        if (_narration)
        {
            _audioSource.Stop();
            _audioSource.clip = _narration;
            _audioSource.loop = false;
            _audioSource.Play();
        }        
    }
}
