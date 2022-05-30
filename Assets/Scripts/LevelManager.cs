using UnityEngine;
using Variables;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private MazeGenerator mazeGenerator;

    private void Start()
    {
        mazeGenerator.StartMazeGeneration();
    }

    private void Update()
    {
    }

    private void CreateMaze()
    {
    }

    private void SetCharacterAtStart()
    {
    }

    private void IncreaseLevel()
    {
    }
}