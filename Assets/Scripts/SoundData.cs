using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Overworld/Sound Data")]
public class SoundData : ScriptableObject
{
    public List<AudioClip> audioClips;
}