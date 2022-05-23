using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOne : MonoBehaviour
{
    public void ChangeToLevelOne()
    {
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }
}