using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Ending", menuName = "Ending")]
public class EndingObject : ScriptableObject
{
    public MementoObject[] _conditions;
    public string _endingText;
    public AudioClip _endingAudio;
    public AudioClip _endingVO;
    public Sprite _endingSprite;

    public bool RelevantEnding = false;
}