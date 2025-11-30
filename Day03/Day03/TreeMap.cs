using System;
using System.Collections.Generic;
using System.Text;

namespace Day03;

internal class TreeMap
{
    private HashSet<(int row, int col)> _trees = new();
    private int _width = 0;

    public int Height { get; private set; }

    public TreeMap(string fn)
    {
        ParseInput(fn);
    }

    public bool HasTree(int row, int col)
    {
        if (row < 0 || row >= Height)
            throw new ArgumentOutOfRangeException(nameof(row), "Row is out of bounds.");

        int wrappedCol = col % _width;
        return _trees.Contains((row, wrappedCol));
    }

    public int TraverseAndCountTrees(int right, int down)
    {
        int treeCount = 0;
        int row = 0;
        int col = 0;

        while (row < Height)
        {
            if (HasTree(row, col))
            {
                treeCount++;
            }

            row += down;
            col += right;
        }

        return treeCount;
    }

    public int Count { get { return _trees.Count; } }

    private void ParseInput(string fn)
    {
        var appDir = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(appDir, "Data", fn);

        int row = 0;
        var lines = File.ReadAllLines(filePath);

        _width = lines[0].Length;
        Height = lines.Length;

        foreach (var line in lines)
        {
            for (int col = 0; col < line.Length; col++)
            {
                if (line[col] == '#')
                {
                    _trees.Add((row, col));
                }
            }
            row++;
        }
    }
}
