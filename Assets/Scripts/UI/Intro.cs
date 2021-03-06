﻿using System.Collections;
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
    private AudioSource _ambientMusic;
    [SerializeField]
    private AudioSource _voiceOver;

    private Animator _animator;

    private void Awake()
    {

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FirstPersonController.Instance.enabled = false;

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
        FirstPersonController.Instance.enabled = true;
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
            yield return new WaitWhile(()=> { return _audioSource.isPlaying && !Input.GetMouseButtonDown(0); });
        }  else
        {
            yield return new WaitForSeconds(.5f);
        }
        _audioSource.Stop();
        _audioSource.clip = null;

        _animator.SetInteger("IntroState", 2);
        _ambientMusic.Play();
        _ambientMusic.GetComponent<FadeAmbienceAfter>().Fade();
        yield return wait;

        if (_narration)
        {
            _audioSource.Stop();
            _voiceOver.Stop();
            _voiceOver.clip = _narration;
            _voiceOver.loop = false;
            _voiceOver.Play();
        }        
    }
}
