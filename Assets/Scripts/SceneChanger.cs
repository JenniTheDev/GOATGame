using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadSettingsMenu()
    {
        // TODO: Add scene change event
        SceneManager.LoadScene("Settings");
    }

    public void LoadHighScoreMenu()
    {
        // TODO: Add scene change event
        SceneManager.LoadScene("HighScores");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        // TODO: Add scene change event
        SceneManager.LoadScene("LevelOne");
    }

    public void ExitGame()
    {
        // TODO: Add scene change event
        Application.Quit();
    }
}