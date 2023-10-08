using System;
using System.Collections.Generic;
using UnityEngine;

public static class CastUtil
{
    /// <summary>
    /// 発生地点からの間に塞がれていないものを返す
    /// </summary>
    /// <param name="point"></param>
    /// <param name="radius"></param>
    /// <param name="AddEvent"></param>
    /// <returns></returns>
    public static Collider[] BetweenOverlapSphere(Vector3 point, float radius, Action<Collider> AddEvent = null)
    {
        var colliders = Physics.OverlapSphere(point, radius);
        if (colliders.Length <= 0) return null;
        List<Collider> result = new List<Collider>(32);
        foreach (var col in colliders.AsSpan<Collider>())
        {
            if (Physics.Linecast(col.transform.position, point)) continue;
            result.Add(col);
            AddEvent?.Invoke(col);
        }
        return result.ToArray();
    }
}
