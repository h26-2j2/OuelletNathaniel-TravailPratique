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
        Destroy(audioSource.gameObject, 9); // Thank you web build for your remarkable inability to function normally, can't even take the length of a sound without throwing errors and making the ENTIRE game stop working
    }
}
