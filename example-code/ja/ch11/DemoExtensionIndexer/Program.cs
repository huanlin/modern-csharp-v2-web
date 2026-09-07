Console.WriteLine("=== C# 15 拡張インデクサー ===");
Console.WriteLine("前方にのみ進むシーケンスから numbers[4] を読み取ります:");

IEnumerable<int> numbers = TraceSequence();
int fifth = numbers[4];

Console.WriteLine("結果: " + fifth);

static IEnumerable<int> TraceSequence()
{
    for (int value = 1; value <= 10; value++)
    {
        Console.WriteLine("  yield: " + value);
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
