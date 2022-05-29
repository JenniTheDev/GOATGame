using PathFinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : Node<Vector2Int>
{
    public bool visited = false;

    public bool[] flag =
    {
        true,
        true,
        true,
        true
    };

    public int x
    { get { return Value.x; } }

    public int y
    { get { return Value.y; } }

    public delegate void DelegateSetDirFlag(
            int x,
            int y,
            Direction dir,
            bool f);

    public DelegateSetDirFlag onSetDirFlag;

    private Maze _maze;

    // constructor
    public Cell(int c, int r, Maze maze)
      : base(new Vector2Int(c, r))
    {
        _maze = maze;
    }

    public void SetDirFlag(
      Direction dir,
      bool f)
    {
        flag[(int)dir] = f;
        onSetDirFlag?.Invoke(Value.x, Value.y, dir, f);
    }

    public override List<Node<Vector2Int>> GetNeighbours()
    {
        List<Node<Vector2Int>> neighbours = new List<Node<Vector2Int>>();
        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            int x = Value.x;
            int y = Value.y;
            switch (dir)
            {
                case Direction.Up:
                    if (y < _maze.NumRows - 1)
                    {
                        ++y;
                        if (!flag[(int)dir])
                        {
                            neighbours.Add(_maze.GetCell(x, y));
                        }
                    }
                    break;

                case Direction.Right:
                    if (x < _maze.NumCols - 1)
                    {
                        ++x;
                        if (!flag[(int)dir])
                        {
                            neighbours.Add(_maze.GetCell(x, y));
                        }
                    }
                    break;

                case Direction.Down:
                    if (y > 0)
                    {
                        --y;
                        if (!flag[(int)dir])
                        {
                            neighbours.Add(_maze.GetCell(x, y));
                        }
                    }
                    break;

                case Direction.Left:
                    if (x > 0)
                    {
                        --x;
                        if (!flag[(int)dir])
                        {
                            neighbours.Add(_maze.GetCell(x, y));
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        return neighbours;
    }
}