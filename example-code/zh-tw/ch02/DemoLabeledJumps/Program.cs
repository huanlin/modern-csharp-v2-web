// 示範 C# 15 具標籤的跳躍陳述式（labeled break 與 continue）

Console.WriteLine("=== 示範 C# 15 具標籤的 break 與 continue ===\n");

Cell[,] grid = {
    { new(IsObstacle: false), new(IsObstacle: true),  new(IsObstacle: false) }, // 第 0 列含障礙物
    { new(IsObstacle: false), new(IsTarget: true),    new(IsObstacle: false) }, // 第 1 列含目標
    { new(IsObstacle: false), new(IsObstacle: false), new(IsObstacle: false) },
};

int rows = grid.GetLength(0);
int cols = grid.GetLength(1);
(int Row, int Col)? targetPosition = null;

searchLoop: for (int r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        if (grid[r, c].IsObstacle)
        {
            Console.WriteLine($"在 ({r}, {c}) 發現障礙物，跳過此列剩餘單元格，直接推進到下一列");
            continue searchLoop; // (1) 跳過本列剩餘單元格，直接推進到外層下一列
        }

        Console.WriteLine($"正在掃描單元格 ({r}, {c})...");

        if (grid[r, c].IsTarget)
        {
            Console.WriteLine($"在 ({r}, {c}) 尋獲目標！");
            targetPosition = (r, c);
            break searchLoop;    // (2) 直接跳出整個 searchLoop 外層迴圈
        }
    }
}

if (targetPosition is { } pos)
{
    Console.WriteLine($"\n搜尋完畢，目標位置：({pos.Row}, {pos.Col})");
}
else
{
    Console.WriteLine("\n未尋獲目標。");
}

public readonly record struct Cell(bool IsObstacle = false, bool IsTarget = false);

