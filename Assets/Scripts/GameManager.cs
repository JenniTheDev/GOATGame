using UnityEngine;
using Variables;
using SOEvents.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private MazeGenerator mazeGenerator;
    [SerializeField] private GameEventGameState onGameStateChange;
    [SerializeField] private GameState currentState = GameState.None;

    public GameState CurrentState
    { get { return this.currentState; } }

    public IntVariable CurrentLevel
    { get { return this.currentLevel; } }

    public void LoadGame()
    {
        currentState = GameState.Loading;
        BroadcastGameStateChanged(); // I don't think these are right?
    }

    public void PlayGame()
    {
        currentState = GameState.Playing;

        BroadcastGameStateChanged();
    }

    public void NextLevel()
    {
        currentLevel.IntValue++;
        mazeGenerator.IncreaseMaze();
        BroadcastGameStateChanged();
    }

    public void EndGame()
    {
        currentState = GameState.GameOver;
        BroadcastGameStateChanged();
    }

    // private void CreateMaze() => mazeGenerator.StartMazeGeneration();

    private void SetCharacterAtStart()
    {
    }

    //private void IncreaseLevel()
    //{
    //}

    private void BroadcastGameStateChanged()
    {
        onGameStateChange.Raise(this.currentState);
    }
}