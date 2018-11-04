using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private const string SCREEN_TO_OPEN = "PlayScreen";

    public void LaunchPlayScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
