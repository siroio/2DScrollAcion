using System;
using UnityEngine;

public static class TransformUtil
{
    public static bool CheckFront(this Transform self, Transform target)
        => (Vector3.Dot(target.position - self.position, self.forward) > 0);

    public static bool CheckFront(this Transform self, Vector3 target)
        => (Vector3.Dot(target - self.position, self.forward) > 0);

    public static Vector3[] AroundPoints(this Transform self, Vector3 axis, float radius, int count)
    {
        var angle = 360F / count;
        if (count < 1) return Array.Empty<Vector3>();
        var points = new Vector3[count];

        for (var i = 0; i < count; i++)
        {
            points[i] = (Quaternion.AngleAxis(angle * i, axis) * self.right * radius) + self.position;
        }

        return points;
    }

    public static Vector3[] AroundPoints(this Transform self, Vector3 axis, float radius, int count, Action<Vector3> point = null)
    {
        var angle = 360F / count;
        if (count < 1) return Array.Empty<Vector3>();
        var points = new Vector3[count];

        for (var i = 0; i < count; i++)
        {
            points[i] = (Quaternion.AngleAxis(angle * i, axis) * self.right * radius) + self.position;
            point?.Invoke(points[i]);
        }

        return points;
    }
}
