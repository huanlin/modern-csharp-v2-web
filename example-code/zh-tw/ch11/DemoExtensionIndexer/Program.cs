Console.WriteLine("=== C# 15 擴充索引子 ===");
Console.WriteLine("從只能向前巡訪的序列讀取 numbers[4]：");

IEnumerable<int> numbers = TraceSequence();
int fifth = numbers[4];

Console.WriteLine("結果：" + fifth);

static IEnumerable<int> TraceSequence()
{
    for (int value = 1; value <= 10; value++)
    {
        Console.WriteLine("  產生：" + value);
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
