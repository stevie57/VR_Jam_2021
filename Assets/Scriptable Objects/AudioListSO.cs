using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misc/AudioListSO")]
public class AudioListSO : ScriptableObject
{
    public List<AudioClip> ClipList = new List<AudioClip>();

    public AudioClip RandomClip()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        int randomNumber = UnityEngine.Random.Range(0, ClipList.Count);
        return ClipList[randomNumber];
    }

}
