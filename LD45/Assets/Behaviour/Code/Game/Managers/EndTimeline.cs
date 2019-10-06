using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimeline : MonoBehaviour
{
    public void EndText()
    {
        TimelineManager.tm.EndText();
    }

    public void End()
    {
        TimelineManager.tm.IntroEnd();
    }
}