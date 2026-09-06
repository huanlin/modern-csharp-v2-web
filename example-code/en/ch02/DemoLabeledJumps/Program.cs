// Demonstrating C# 15 labeled jump statements (labeled break and continue)

Console.WriteLine("=== C# 15 Labeled break and continue Demo ===\n");

Cell[,] grid = {
    { new(IsObstacle: false), new(IsObstacle: true),  new(IsObstacle: false) }, // Row 0 contains an obstacle
    { new(IsObstacle: false), new(IsTarget: true),    new(IsObstacle: false) }, // Row 1 contains the target
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
            Console.WriteLine($"Obstacle encountered at ({r}, {c}). Skipping remainder of this row.");
            continue searchLoop; // (1) Skip remaining cells in this row and advance to next outer loop iteration
        }

        Console.WriteLine($"Scanning cell ({r}, {c})...");

        if (grid[r, c].IsTarget)
        {
            Console.WriteLine($"Target found at ({r}, {c})!");
            targetPosition = (r, c);
            break searchLoop;    // (2) Break out of the entire searchLoop outer loop
        }
    }
}

if (targetPosition is { } pos)
{
    Console.WriteLine($"\nSearch completed. Target position: ({pos.Row}, {pos.Col})");
}
else
{
    Console.WriteLine("\nTarget not found.");
}

public readonly record struct Cell(bool IsObstacle = false, bool IsTarget = false);

