using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneController.instance.LoadScene(sceneName);
    }
}
