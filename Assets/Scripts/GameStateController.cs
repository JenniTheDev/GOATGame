using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameStateController", menuName = "ScriptableObjects/GameStateController")]
public class GameStateController : ScriptableObject
{
    public event Action<GameState> OnGameStateChanged;

    public void RaiseGameStateChange(GameState newState) => OnGameStateChanged?.Invoke(newState);
}