using System.Runtime.InteropServices;

Console.WriteLine("=== C# 15 記憶體安全語法 ===");

int* buffer = stackalloc int[3];
unsafe(buffer[0] = 10);
unsafe(buffer[1] = 20);
unsafe(buffer[2] = 30);

int sum = unsafe(buffer[0] + buffer[1] + buffer[2]);
Console.WriteLine("指標緩衝區總和：" + sum);
Console.WriteLine("sizeof(decimal)：" + sizeof(decimal));

NumberBits bits = new() { AsInt = 0x3F800000 };
Console.WriteLine("以 float 顯示明確配置欄位：" + bits.AsFloat);

[StructLayout(LayoutKind.Explicit)]
public struct NumberBits
{
    [FieldOffset(0)]
    public safe int AsInt;

    [FieldOffset(0)]
    public safe float AsFloat;
}
