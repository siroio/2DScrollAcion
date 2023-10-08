using System;
using UnityEngine;

public static class QuaternionUtil
{
    /// <summary>
    /// Reverse Quaternion
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static Quaternion Reverse(this Quaternion self)
    {
        return new Quaternion(-self.x, -self.y, -self.z, -self.w);
    }
}
