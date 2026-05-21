using UnityEngine;

public class VoiceLinePlayer : MonoBehaviour
{
    public static VoiceLinePlayer instance;
    public Vector2 hintCooldown = new Vector2(5f, 10f);
    AudioSource audioSource;
    float soundLength;
    public SoundData instructionPool;
    public SoundData congratulatePool;
    public SoundData finalPool;

    void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLine(AudioClip audioClip, float volume = 1f, float pitch = 1f)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        soundLength = audioSource.clip.length * 1.2f / pitch;
        audioSource.Play();
    }
}
