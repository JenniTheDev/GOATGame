using SOEvents.Listeners;
using UnityEngine;
using Variables;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameEventListenerGameState onGameStateChangeListener;
    [SerializeField] private GameObject player;
    [SerializeField] private IntVariable startX;
    [SerializeField] private IntVariable startY;

    // How do I make the listener do this method on the game state change to playing?
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