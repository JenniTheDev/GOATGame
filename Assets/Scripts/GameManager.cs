using UnityEngine;
using Variables;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private MazeGenerator mazeGenerator;

    [SerializeField] private GameStateController controller;

    public IntVariable CurrentLevel
    { get { return this.currentLevel; } }

    public void Awake()
    {
        controller.OnGameStateChanged += OnGameStateChanged;
    }

    public void Start()
    {
        controller.RaiseGameStateChange(GameState.Loading);
        Console.WriteLine("Game Loading");
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

    private void OnGameStateChanged(GameState toState)
    {
        if (toState == GameState.Playing)
        {
            Console.WriteLine("Game start playing");
        }
    }
}