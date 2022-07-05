using UnityEngine;
using Variables;
using SOEvents.Events;
using System;
using SOEvents.Listeners;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private MazeGenerator mazeGenerator;
    [SerializeField] private GameEventGameState onGameStateChange;

    // [SerializeField] private GameEventListenerGameState onGameStateChangeListener;
    [SerializeField] private GameState currentState = GameState.None;

    public GameState CurrentState
    { get { return this.currentState; } }

    public IntVariable CurrentLevel
    { get { return this.currentLevel; } }

    public void Awake()
    {
        LoadGame();
        BroadcastGameStateChanged();
    }

    public void LoadGame()
    {
        currentState = GameState.Loading;
        mazeGenerator.StartMazeGeneration();
        BroadcastGameStateChanged(); // I don't think these are right?
    }

    public void PlayGame()
    {
        currentState = GameState.Playing;
        // SetCharacterAtStart
        StartTimer();
        BroadcastGameStateChanged();
    }

    private void StartTimer()
    {
        throw new NotImplementedException();
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

    //private void IncreaseLevel()
    //{
    //}

    private void BroadcastGameStateChanged()
    {
        onGameStateChange.Raise(this.currentState);
    }
}