Console.WriteLine("=== C# 15 extension indexer ===");
Console.WriteLine("Reading numbers[4] from a forward-only sequence:");

IEnumerable<int> numbers = TraceSequence();
int fifth = numbers[4];

Console.WriteLine("Result: " + fifth);

static IEnumerable<int> TraceSequence()
{
    for (int value = 1; value <= 10; value++)
    {
        Console.WriteLine("  yielded " + value);
        yield return value;
    }
}

public static class SequenceIndexer
{
    extension(IEnumerable<int> sequence)
    {
        public int this[int index] => sequence.ElementAt(index);
    }
}
