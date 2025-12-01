using UnityEngine;

public class RestartScript : MonoBehaviour
{
    public void LoadCurrentScene()
    { UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
}
