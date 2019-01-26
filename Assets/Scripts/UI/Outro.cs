using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    
    public EndingObject Ending
    {
        set
        {
            _text.text = value._endingText;
            _isPlaying = true;
            GetComponent<Animator>().SetTrigger("Start");
        }
    }

    private bool _isPlaying;

    public void OnFinshOutro()
    {
        var async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        async.allowSceneActivation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying && Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetTrigger("Skip");
        }
    }
}
