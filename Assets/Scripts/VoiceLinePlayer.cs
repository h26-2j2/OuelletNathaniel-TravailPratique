using UnityEngine;

public class VoiceLinePlayer : MonoBehaviour
{
    public static VoiceLinePlayer instance;
    public Vector2 instructionRepeatDelayRange = new Vector2(10f, 14f);
    AudioSource audioSource;
    float instructionRepeatDelay = 3.5f;
    public AudioClip instruction;
    public SoundData congratulatePool;

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

    private void Update()
    {
        instructionRepeatDelay -= Time.deltaTime;

        if (instructionRepeatDelay <= 0)
        {
            instructionRepeatDelay = Random.Range(instructionRepeatDelayRange.x, instructionRepeatDelayRange.y);
            PlayInstruction();
        }
    }

    public void PlayInstruction()
    {
        PlayLine(instruction);
    }

    public void PlayCongratulation()
    {
        PlayLine(congratulatePool.audioClips[Random.Range(0, congratulatePool.audioClips.Count)]);
    }

    void PlayLine(AudioClip audioClip, float volume = 1f, float pitch = 1f)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        instructionRepeatDelay = Random.Range(instructionRepeatDelayRange.x, instructionRepeatDelayRange.y) + (audioSource.clip.length * 1.2f / pitch);
        audioSource.Play();
    }
}
