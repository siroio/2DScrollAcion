using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtil
{
    /// <summary>
    /// 渡された複数のタグを比較して同じものがあるか確かめる
    /// </summary>
    /// <param name="self"></param>
    /// <param name="tags"></param>
    /// <returns>Tuple (tag, bool)</returns>
    public static (string tag, bool equal) CompareTags(this GameObject self, params string[] tags)
    {
        foreach (var t in tags)
            if (self.CompareTag(t)) return (t, true);
        return (string.Empty, false);
    }

    /// <summary>
    /// 渡された複数のタグを比較してDictionaryで返す
    /// </summary>
    /// <param name="self"></param>
    /// <param name="tags"></param>
    /// <returns>Dictionary(tag, compare)</returns>
    public static Dictionary<string, bool> CompareTags(this GameObject self, in Span<string> tags)
    {
        var result = new Dictionary<string, bool>(tags.Length);
        foreach (var t in tags) result.Add(t, self.CompareTag(t));
        return result;
    }

    /// <summary>
    /// 渡された複数のタグを比較して同じものがあるか確かめる
    /// </summary>
    /// <param name="self"></param>
    /// <param name="tags"></param>
    /// <returns>Tuple (tag, bool)</returns>
    public static (string tag, bool equal) CompareTags(this Collider self, params string[] tags)
    {
        foreach (var t in tags)
            if (self.CompareTag(t)) return (t, true);
        return (string.Empty, false);
    }

    /// <summary>
    /// 渡された複数のタグを比較してDictionaryで返す
    /// </summary>
    /// <param name="self"></param>
    /// <param name="tags"></param>
    /// <returns>Dictionary(tag, compare)</returns>
    public static Dictionary<string, bool> CompareTags(this Collider self, in Span<string> tags)
    {
        var result = new Dictionary<string, bool>(tags.Length);
        foreach (var t in tags) result.Add(t, self.CompareTag(t));
        return result;
    }
}
