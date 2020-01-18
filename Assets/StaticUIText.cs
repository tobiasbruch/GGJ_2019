using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StaticUIText : MonoBehaviour
{
    public TextMeshProUGUI TF;
    public static StaticUIText Instance;
    public Animator Animator;

    private void Awake()
    {
        Instance = this;
    }

    string text;

    public void SetText(string Text)
    {
        
        Animator.SetBool("Shown", true);
        TF.SetText("");
        text = Text;
        TF.gameObject.SetActive(false);
        TF.gameObject.SetActive(true);

        StopCoroutine("UnsetText");
        Invoke("UnsetText", 2);
        Invoke("SetText", 0.01f);

    }
 
    void SetText()
    {
        TF.SetText(text);
    }
    public void UnsetText()
    {
        Animator.SetBool("Shown", false);
    }
    
}
