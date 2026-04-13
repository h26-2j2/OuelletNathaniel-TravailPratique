using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundObject;

    void Awake()
    {
        if(instance == null || instance == this) 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySound(AudioClip audioClip, float volume = 1f, float pitch = 1f)
    {
        AudioSource audioSource = Instantiate(soundObject, instance.transform);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
        float soundLength = audioSource.clip.length * 1.25f / pitch;
        Destroy(audioSource.gameObject, soundLength);
    }
}
