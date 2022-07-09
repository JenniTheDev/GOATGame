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

    public IntVariable CurrentLevel
    { get { return this.currentLevel; } }

    public void Awake()
    {
    }

    public void LoadGame()
    {
    }

    public void PlayGame()
    {
    }

    private void StartTimer()
    {
        throw new NotImplementedException();
    }

    public void NextLevel()
    {
    }

    public void EndGame()
    {
    }
}