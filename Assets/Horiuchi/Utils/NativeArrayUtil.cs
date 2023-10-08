using Unity.Collections;

public static class NativeArrayUtil
{
    /// <summary>
    /// NativeArrayをdefの値で埋めて初期化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="self"></param>
    /// <param name="def"></param>
    public static void ClearArray<T>(ref this NativeArray<T> self, T def = default) where T : struct
    {
        for (var i = 0; i < self.Length; ++i) self[i] = def;
    }
}
