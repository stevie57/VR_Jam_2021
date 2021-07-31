using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misc/AudioListSO")]
public class AudioHandlerWorld_SFX : ScriptableObject
{
    public List<AudioClip> WindClips = new List<AudioClip>();
    public List<AudioClip> WaterClips = new List<AudioClip>();
    public List<AudioClip> EarthClips = new List<AudioClip>();
    public List<AudioClip> FireClips = new List<AudioClip>();

    public AudioClip RandomClip(List<AudioClip> soundList)
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        int randomNumber = UnityEngine.Random.Range(0, soundList.Count);
        return soundList[randomNumber];
    }

}
