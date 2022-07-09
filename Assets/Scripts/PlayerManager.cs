using SOEvents.Listeners;
using System;
using UnityEngine;
using Variables;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameStateController controller;
    [SerializeField] private GameObject player;
    [SerializeField] private IntVariable startX;
    [SerializeField] private IntVariable startY;

    public void Start()
    {
        controller.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState toState)
    {
        if (toState == GameState.Playing)
        {
            Console.WriteLine("Spawning Player");
            GetStartLocation();
            SpawnAtStart();
        }
    }

    private void SpawnAtStart()
    {
        Vector2 startPoint;
        startPoint.x = startX;
        startPoint.y = startY;
        Instantiate(player, GetStartLocation(), Quaternion.identity);
    }

    private Vector2 GetStartLocation()
    {
        Vector2 startPoint;
        startPoint.x = startX;
        startPoint.y = startY;
        return startPoint;
    }
}