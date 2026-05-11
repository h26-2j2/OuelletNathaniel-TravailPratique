using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField]
    string targetTag = "Apple";
    [SerializeField]
    GameObject appleSprites; // GameObject meant to contain sprites as children
    int appleIndex;
    [SerializeField]
    SoundData basketSounds;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.isTrigger && collision.gameObject.CompareTag(targetTag))
        {
            GameObject parent = collision.transform.parent.gameObject;

            appleSprites.transform.GetChild(appleIndex).gameObject.SetActive(true);
            appleIndex++;
            AppleManager.instance.RemoveAppleFromPool(parent.GetComponent<Apple>());
            parent.SetActive(false);
            SoundManager.instance.PlaySound(basketSounds.audioClips[Random.Range(0, basketSounds.audioClips.Count)]);
            AppleCounter.instance.changeCounter();
        }
    }
}
