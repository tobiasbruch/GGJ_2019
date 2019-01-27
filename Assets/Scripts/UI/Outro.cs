using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Outro : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private AudioSource _voiceOver;

    public EndingObject Ending
    {
        set
        {
            _text.text = value._endingText;
            _isPlaying = true;
            GetComponent<Animator>().SetTrigger("Start");
            FirstPersonController.Instance.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _voiceOver.Stop();
            _voiceOver.clip = value._endingVO;
            _voiceOver.loop = false;
            _voiceOver.Play();
        }
    }

    private bool _isPlaying;

    public void OnRestartClicked()
    {
        var async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        async.allowSceneActivation = true;
    }

}
