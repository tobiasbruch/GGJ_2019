using System.Collections;
using UnityEngine;

public class FadeAmbienceAfter : MonoBehaviour
{

    [SerializeField]
    private AudioSource _audioSource;

    public void Fade()
    {
        StartCoroutine(StopAfter());
    }

    private IEnumerator StopAfter()
    {
        yield return new WaitForSeconds(15);
        _audioSource.Stop();
        
    }
}
