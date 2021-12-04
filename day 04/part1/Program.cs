using AdventCommon;
var lines = File.ReadAllLines("input.txt");

var choices_ = lines[0].Split(",").Select(int.Parse);
var choices = Enumerable.Range(0, choices_.Count()).Select(i => choices_.Take(i));

// build board as 2d array
var boards = string.Join("\n", lines.Skip(2))
    .Split("\n\n")
    .Select(x => x.Split("\n"))
    .Select(x => x.Select(y => y.Split(" ", StringSplitOptions.RemoveEmptyEntries)))
    .Select(x => x.Select(y => y.Select(z => int.Parse(z.Trim()))));


var getUnmarkedNums = (IEnumerable<IEnumerable<int>> board, IEnumerable<int> nums) => {
    return board
        .Aggregate((acc, cur) => {
            var lst = acc.ToList();
            lst.AddRange(cur);
            return lst;
        })
        .Except(nums);
};

var checkWin = (IEnumerable<IEnumerable<int>> board, IEnumerable<int> nums) => {
    var boardLen = board.Count();
    // check rows
    for (var i = 0; i < boardLen; i++)
    {
        var row = board.ElementAt(i);
        if (row.Intersect(nums).Count() == row.Count())
        {
            return getUnmarkedNums(board, nums).Sum();
        }
    }

    // check cols
    for (var i = 0; i < boardLen; i++)
    {
        if (board.Select(x => x.ElementAt(i)).Intersect(nums).Count() == boardLen)
        {
            return getUnmarkedNums(board, nums).Sum();
        }
    }

    return -1;
};


foreach (var choice in choices)
{
    var found = false;
    foreach (var board in boards)
    {
        var win = checkWin(board, choice);
        if (win > -1)
        {
            Console.WriteLine(win * choice.Last());
            found = true;
            break;
        }
    }
    if (found)
    {
        break;
    }
}

