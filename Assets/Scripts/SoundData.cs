using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Pommes/Sound Data")] // Crée un asset qui contient des valeurs.
public class SoundData : ScriptableObject
{
    public List<AudioClip> audioClips;
}