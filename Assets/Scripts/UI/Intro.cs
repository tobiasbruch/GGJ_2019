using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OnIntroFinished()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GetComponent<Animator>().SetTrigger("Skip");
    }
}
