using System;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    private int _rows;
    private int _cols;
    private Cell[,] cells;

    public Maze(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;

        cells = new Cell[_rows, _cols];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                cells[i, j] = new Cell(i, j, this);
            }
        }
    }

    public int NumRows
    { get { return _rows; } }

    public int NumCols
    { get { return _cols; } }

    public Cell GetCell(int i, int j) => cells[i, j];

    public int GetCellCount() => _rows * _cols;

    public List<Tuple<Direction, Cell>> GetNeighboursNotVisited(
        int cx,
        int cy)
    {
        List<Tuple<Direction, Cell>> neighbours =
            new List<Tuple<Direction, Cell>>();

        foreach (Direction dir in Enum.GetValues(
          typeof(Direction)))
        {
            int x = cx;
            int y = cy;

            switch (dir)
            {
                case Direction.Up:
                    if (y < _rows - 1)
                    {
                        ++y;
                        if (!cells[x, y].visited)
                        {
                            neighbours.Add(new Tuple<Direction, Cell>(
                              Direction.Up,
                              cells[x, y])
                            );
                        }
                    }
                    break;

                case Direction.Right:
                    if (x < _cols - 1)
                    {
                        ++x;
                        if (!cells[x, y].visited)
                        {
                            neighbours.Add(new Tuple<Direction, Cell>(
                              Direction.Right,
                              cells[x, y])
                            );
                        }
                    }
                    break;

                case Direction.Down:
                    if (y > 0)
                    {
                        --y;
                        if (!cells[x, y].visited)
                        {
                            neighbours.Add(new Tuple<Direction, Cell>(
                              Direction.Down,
                              cells[x, y])
                            );
                        }
                    }
                    break;

                case Direction.Left:
                    if (x > 0)
                    {
                        --x;
                        if (!cells[x, y].visited)
                        {
                            neighbours.Add(new Tuple<Direction, Cell>(
                              Direction.Left,
                              cells[x, y])
                            );
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        return neighbours;
    }

    public void RemoveCellWall(
        int x,
        int y,
        Direction direction)
    {
        if (direction != Direction.None)
        {
            Cell cell = GetCell(x, y);
            cell.SetDirFlag(direction, false);
        }
        Direction opposite = Direction.None;
        switch (direction)
        {
            case Direction.Up:
                if (y < _rows - 1)
                {
                    opposite = Direction.Down;
                    ++y;
                }
                break;

            case Direction.Right:
                if (x < _cols - 1)
                {
                    opposite = Direction.Left;
                    ++x;
                }
                break;

            case Direction.Down:
                if (y > 0)
                {
                    opposite = Direction.Up;
                    --y;
                }
                break;

            case Direction.Left:
                if (x > 0)
                {
                    opposite = Direction.Right;
                    --x;
                }
                break;
        }
        if (opposite != Direction.None)
        {
            Cell cellOne = GetCell(x, y);
            cellOne.SetDirFlag(opposite, false);
        }
    }
}