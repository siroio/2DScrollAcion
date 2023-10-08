
/// <summary>
/// 円環の数
/// </summary>
public sealed class RingNumber
{
    private readonly int start;
    private readonly int end;
    private int current;

    public RingNumber(int start, int end)
    {
        current = start;
        this.end = end;
    }

    public int Next() => current += current < end ? 1 : -current + start;

    public int Begin() => current += current > start ? -1 : -current + end;

    public int Current => current;
}
