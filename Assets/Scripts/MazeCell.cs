using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Walls;

    [SerializeField]
    private SpriteRenderer Highlight;

    public Cell Cell { get; set; }

    private void Start()
    {
        SetHighlight(false);
    }

    public void SetHighlight(bool flag)
    {
        Highlight.gameObject.SetActive(flag);
    }

    public void SetHighColor(Color color)
    {
        Highlight.color = color;
    }

    public void SetActive(Direction dir, bool flag)
    {
        Walls[(int)dir].SetActive(flag);
    }
}