using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager sm;

    void Awake() { sm = this; }

    public TrackLevel[] trackLevels;

    public AudioSource trackSource;

    public static void SetLevel(int level)
    {
        foreach (var trackLevel in sm.trackLevels)
        {
            if (trackLevel.level == level)
            {
                float sourceTime = sm.trackSource.time;
                sm.trackSource.clip = trackLevel.track;
                sm.trackSource.time = sourceTime;
                sm.trackSource.Play();


                //float ratio = source.time / source.clip.length;

                //source.clip = tracks[index];
                //source.time = source.clip.length * ratio;
                //source.Play();


                return;
            }
        }
    }
}

[Serializable]
public struct TrackLevel
{
    public AudioClip track;
    public int level;
}


//public class AudioManager : MonoBehaviour
//{
//    AudioSource source;
//    public AudioClip[] tracks;

//    int index;
//    int Index
//    {
//        get { return index; }
//        set
//        {
//            index = value;
//            UpdateTrack();
//        }
//    }

//    void Awake()
//    {
//        source = GetComponent<AudioSource>();
//    }

//    public void ChangeTrack(int lapCount)
//    {
//        int newIndex = lapCount - 1;
//        if (newIndex == index)
//            return;
//        Index = newIndex;
//    }

//    void UpdateTrack()
//    {
//        float ratio = source.time / source.clip.length;

//        source.clip = tracks[index];
//        source.time = source.clip.length * ratio;
//        source.Play();
//    }
//}