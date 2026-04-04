using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    public string sceneToLoad;

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
