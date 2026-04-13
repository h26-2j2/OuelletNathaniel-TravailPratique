using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip audioClip;
    public SoundData soundData;
    public Vector2 volume = new Vector2(1f, 1f);
    public Vector2 pitch = new Vector2(1f, 1f);

    public void Play()
    {
        if (audioClip == null)
        {
            SoundManager.instance.PlaySound(soundData.audioClips[Random.Range(0, soundData.audioClips.Count)], Random.Range(volume.x, volume.y), Random.Range(pitch.x, pitch.y));
            return;
        }
        SoundManager.instance.PlaySound(audioClip, Random.Range(volume.x, volume.y), Random.Range(pitch.x, pitch.y));
    }
}
