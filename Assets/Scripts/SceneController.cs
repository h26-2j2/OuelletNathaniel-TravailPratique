using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject fadeOut;
    [SerializeField] float fadeDelay;

    void Awake()
    {
        if(instance == null || instance == this) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(SwitchScene(sceneName));
    }

    IEnumerator SwitchScene(string sceneName)
    {
        Instantiate(fadeOut);
        yield return new WaitForSeconds(4.75f);
        var asyncLoadScene = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoadScene.isDone)
        {
            Debug.Log($"Loading the Scene ({sceneName})");
            yield return null;
        }
        Instantiate(fadeIn);
    }
}
