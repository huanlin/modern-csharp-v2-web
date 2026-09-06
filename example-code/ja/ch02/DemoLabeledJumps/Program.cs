// C# 15 のラベル付きジャンプ文（ラベル付き break および continue）のデモ

Console.WriteLine("=== C# 15 ラベル付き break / continue のデモ ===\n");

Cell[,] grid = {
    { new(IsObstacle: false), new(IsObstacle: true),  new(IsObstacle: false) }, // 行 0 に障害物あり
    { new(IsObstacle: false), new(IsTarget: true),    new(IsObstacle: false) }, // 行 1 にターゲットあり
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
            Console.WriteLine($"({r}, {c}) で障害物を検出しました。この行の残りをスキップして次の行へ進みます。");
            continue searchLoop; // (1) この行の残りのセルをスキップし、外側のループの次の反復へ直接進む
        }

        Console.WriteLine($"セル ({r}, {c}) を走査中...");

        if (grid[r, c].IsTarget)
        {
            Console.WriteLine($"({r}, {c}) でターゲットを発見しました！");
            targetPosition = (r, c);
            break searchLoop;    // (2) searchLoop 外側ループ全体を直ちに抜ける
        }
    }
}

if (targetPosition is { } pos)
{
    Console.WriteLine($"\n探索完了。ターゲット位置：({pos.Row}, {pos.Col})");
}
else
{
    Console.WriteLine("\nターゲットは見つかりませんでした。");
}

public readonly record struct Cell(bool IsObstacle = false, bool IsTarget = false);

