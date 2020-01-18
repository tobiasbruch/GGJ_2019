using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StoryCounter : MonoBehaviour
{
    public TextMeshProUGUI TF;
    public ExitDoor ExitDoor;

    private void Start()
    {
        int storyCount = 0;
        int storiesFound = 0;
        foreach (var ending in ExitDoor.GetEndings())
        {
            if (ending.RelevantEnding)
                storyCount++;
            if (PlayerPrefs.HasKey(ending.name))
                storiesFound++;

        }

        TF.SetText(storiesFound.ToString() + "/" + storyCount.ToString() + " Stories Found.");
    }
}
