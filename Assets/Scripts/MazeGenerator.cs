using System.Collections;
using System.Collections.Generic;
using Variables;
using UnityEngine;
using System;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private IntVariable rows;
    [SerializeField] private IntVariable cols;
    [SerializeField] private IntVariable startY;
    [SerializeField] private IntVariable startX;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameStateController controller;

    [SerializeField] private int rowIncrease = 3;
    [SerializeField] private int colIncrease = 4;

    private Stack<Cell> stack = new Stack<Cell>();
    public MazeCell[,] mazeCells;

    public Maze Maze { get; private set; }

    public bool MazeGenerationCompleted { get; private set; } = false;

    public void Awake()
    {
        controller.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState toState)
    {
        if (toState == GameState.Loading)
        {
            Console.WriteLine("Starting Maze Generation.");
            StartMazeGeneration();
        }
        else if (toState == GameState.Playing)
        {
        }
    }

    public void StartMazeGeneration()
    {
        startX.IntValue = -cols / 2;
        startY.IntValue = -rows / 2;

        Maze = new Maze(rows, cols);
        mazeCells = new MazeCell[cols, rows];
        for (int i = 0; i < cols; ++i)
        {
            for (int j = 0; j < rows; ++j)
            {
                GameObject obj = Instantiate(cellPrefab);
                obj.transform.parent = transform;
                Cell cell = Maze.GetCell(i, j);
                cell.onSetDirFlag = OnCellSetDirFlag;
                obj.transform.position = new Vector3(
                  startX + cell.x,
                  startY + cell.y,
                  1.0f);

                mazeCells[i, j] = obj.GetComponent<MazeCell>();
                mazeCells[i, j].Cell = cell;
            }
        }
        CreateNewMaze();
    }

    private void CreateNewMaze()
    {
        // Remove the left wall from
        // the bottom left cell.
        Maze.RemoveCellWall(
          0,
          0,
          Direction.Left);

        // Remove the right wall from
        // the top right cell.
        Maze.RemoveCellWall(
          cols - 1,
          rows - 1,
          Direction.Right);

        // Push the first cell into the stack.
        stack.Push(Maze.GetCell(0, 0));

        // Generate the maze in a coroutine
        // so that we can see the progress of the
        // maze generation in progress.
        StartCoroutine(Generate());
    }

    public void HighlightCell(int i, int j, bool flag)
    {
        mazeCells[i, j].SetHighlight(flag);
    }

    public void RemoveAllHightlights()
    {
        for (int i = 0; i < cols; ++i)
        {
            for (int j = 0; j < rows; ++j)
            {
                mazeCells[i, j].SetHighlight(false);
            }
        }
    }

    public void OnCellSetDirFlag(
      int x,
      int y,
      Direction dir,
      bool f)
    {
        mazeCells[x, y].SetActive(dir, f);
    }

    private bool GenerateStep()
    {
        if (stack.Count == 0) return true;

        Cell cellPeeked = stack.Peek();
        var neighbours = Maze.GetNeighboursNotVisited(cellPeeked.x, cellPeeked.y);

        if (neighbours.Count != 0)
        {
            var index = 0;
            if (neighbours.Count > 1)
            {
                index = UnityEngine.Random.Range(0, neighbours.Count);
            }
            var item = neighbours[index];
            Cell neighbour = item.Item2;
            neighbour.visited = true;
            Maze.RemoveCellWall(cellPeeked.x, cellPeeked.y, item.Item1);

            mazeCells[cellPeeked.x, cellPeeked.y].SetHighlight(true);

            stack.Push(neighbour);
        }
        else
        {
            stack.Pop();
            mazeCells[cellPeeked.x, cellPeeked.y].SetHighlight(false);
        }
        return false;
    }

    private IEnumerator Generate()
    {
        bool flag = false;
        while (!flag)
        {
            flag = GenerateStep();
            yield return null;
            // yield return new WaitForSeconds(0.01f);
        }
        MazeGenerationCompleted = true;
        controller.RaiseGameStateChange(GameState.Playing);
    }

    public void IncreaseMaze()
    {
        rows.IntValue = rowIncrease;
        cols.IntValue = colIncrease;
        StartMazeGeneration();
    }
}