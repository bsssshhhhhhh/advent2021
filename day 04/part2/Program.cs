﻿using AdventCommon;
var lines = File.ReadAllLines("input.txt");

var choices_ = lines[0].Split(",").Select(int.Parse);
var choices = Enumerable.Range(0, choices_.Count()).Select(i => choices_.Take(i).ToArray());

var boards = string.Join("\n", lines.Skip(2))
    .Split("\n\n")
    .Select(x => x.Split("\n"))
    .Select(x => x.Select(y => y.Split(" ").Where(z => z.Length > 0).ToArray()))
    .Select(x => x.Select(y => y.Select(z => int.Parse(z.Trim())).ToArray()).ToArray()).ToArray();


static int[] getUnmarkedNums(int[][] board, int[] nums)
{
    return board
        .Aggregate((acc, cur) => {
            var lst = acc.ToList();
            lst.AddRange(cur);
            return lst.ToArray();
        })
        .Except(nums)
        .ToArray();
}

var checkWin = (int[][] board, int[] nums) => {
    // check rows
    for (var i = 0; i < board.Length; i++)
    {
        var row = board[i];
        if (row.Intersect(nums).Count() == row.Length)
        {
            return getUnmarkedNums(board, nums).Sum();
        }
    }

    // check cols
    for (var i = 0; i < board.Length; i++)
    {
        if (board.Select(x => x[i]).Intersect(nums).Count() == board.Length)
        {
            return getUnmarkedNums(board, nums).Sum();
        }
    }

    return -1;
};

int[][] lastWinningBoard = null;
int[] lastWinningChoices = null;

var winners = new List<int>();

foreach (var choice in choices)
{
    if (winners.Count == choices.Count())
    {
        break;
    }

    for (var i = 0; i < boards.Length; i++)
    {
        if (winners.Contains(i))
        {
            continue;
        }

        var win = checkWin(boards[i], choice);
        if (win > -1)
        {
            winners.Add(i);
            lastWinningBoard = boards[i];
            lastWinningChoices = choice;
        }
    }
}

Console.WriteLine(checkWin(lastWinningBoard, lastWinningChoices) * lastWinningChoices.Last());
