using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Memento", menuName = "Memento")]
public class MementoObject : ScriptableObject
{
    public AudioClip _audioCue;
}