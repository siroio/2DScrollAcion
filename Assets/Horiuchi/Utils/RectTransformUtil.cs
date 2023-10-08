using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformUtil
{
    public static bool InBounds(this RectTransform self, Vector3 point)
    {
        var bounds = self.GetBounds();
        return bounds.Contains(point);
    }

    public static Bounds GetBounds(this RectTransform self)
    {
        var corners = new Vector3[4];
        var min = Vector3Util.Min;
        var max = Vector3Util.Max;
        self.GetWorldCorners(corners);

        for (var i = 0; i < 4; i++)
        {
            min = Vector3.Min(corners[i], min);
            max = Vector3.Max(corners[i], max);
        }

        max.z = 0.0f;
        min.z = 0.0f;

        var bounds = new Bounds(min, Vector3.zero);
        bounds.Encapsulate(max);
        return bounds;
    }
}
