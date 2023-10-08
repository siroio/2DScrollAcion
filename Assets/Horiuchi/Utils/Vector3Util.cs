using UnityEngine;

public static class Vector3Util
{
    public static readonly Vector3 Min = new(float.MinValue, float.MinValue, float.MinValue);
    public static readonly Vector3 Max = new(float.MaxValue, float.MaxValue, float.MaxValue);

    /// <summary>
    /// 方向を取得
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>Normalized Vector3</returns>
    public static Vector3 Direction(this Vector3 from, Vector3 to, bool normalized = true)
    {
        return normalized ? (to - from).normalized : (to - from);
    }

    /// <summary>
    /// Vector3からXYZのみをコピーしてTupleで返す
    /// var (x, y, z) = Vector3Util.toXYZ(self);
    /// </summary>
    /// <param name="self"></param>
    /// <returns>(float, float, float)</returns>
    public static (float x, float y, float z) toXYZ(this Vector3 self)
    {
        return (self.x, self.y, self.z);
    }

    /// <summary>
    /// Vector3をClampする
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
    {
        var x = Mathf.Clamp(value.x, min.x, max.x);
        var y = Mathf.Clamp(value.y, min.y, max.y);
        var z = Mathf.Clamp(value.z, min.z, max.z);

        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Vector3を0 ~ 1 でClampする
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Vector3 Clamp01(Vector3 value)
    {
        var x = Mathf.Clamp01(value.x);
        var y = Mathf.Clamp01(value.y);
        var z = Mathf.Clamp01(value.z);

        return new Vector3(x, y, z);
    }

    /// <summary>
    /// 値をループさせLengthより大きく0より小さくなることはない
    /// </summary>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static Vector3 Repeat(this Vector3 value, Vector3 length)
    {
        value.x = Mathf.Repeat(value.x, length.x);
        value.y = Mathf.Repeat(value.y, length.y);
        value.z = Mathf.Repeat(value.z, length.z);

        return value;
    }

    /// <summary>
    /// 角度の差を返す
    /// </summary>
    /// <param name="current"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector3 DeltaAngle(this Vector3 current, Vector3 target)
    {
        current.x = Mathf.DeltaAngle(current.x, target.x);
        current.y = Mathf.DeltaAngle(current.y, target.y);
        current.z = Mathf.DeltaAngle(current.z, target.z);

        return current;
    }

    /// <summary>
    /// Euler角を180 ~ -180に正規化
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Vector3 NormalizeAngle180(Vector3 angle)
    {
        var (x, y, z) = angle.toXYZ();
        float normal180(float t) => Mathf.Repeat(t + 180, 360) - 180;

        return new Vector3(normal180(x), normal180(y), normal180(z));
    }

    /// <summary>
    /// 距離内か
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static bool InDistance(Vector3 from, Vector3 to, float distance)
    {
        return (to - from).sqrMagnitude < (distance * distance);
    }

    /// <summary>
    /// 距離外か
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static bool OutDistance(Vector3 from, Vector3 to, float distance)
    {
        return (to - from).sqrMagnitude > (distance * distance);
    }

    /// <summary>
    /// 指定したカメラを基準にしたベクトルを返す
    /// </summary>
    /// <param name="input"></param>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector3 FromCamera(Vector3 input, in Camera camera)
    {
        var transform = camera.transform;
        var cameraZ = transform.forward;
        var cameraX = transform.right;

        return cameraX * input.x + cameraZ * input.z;
    }

    /// <summary>
    /// 指定したカメラを基準にしたベクトルを適用
    /// </summary>
    /// <param name="input"></param>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static void FromCamera(ref this Vector3 input, in Camera camera)
    {
        var transform = camera.transform;
        var cameraZ = transform.forward;
        var cameraX = transform.right;

        input = cameraX * input.x + cameraZ * input.z;
    }

    /// <summary>
    /// 指定したカメラを基準にしたベクトルを適用
    /// </summary>
    /// <param name="input"></param>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static void FromCameraXZ(ref this Vector3 input, in Camera camera)
    {
        var cameraForward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = cameraForward * input.z + camera.transform.right * input.x;
    }

    /// <summary>
    /// バネトルクを生成
    /// </summary>
    /// <param name="self"></param>
    /// <param name="target"></param>
    /// <param name="ratio"></param>
    /// <returns></returns>
    public static Vector3 SpringTorque((Vector3 position, Quaternion rotation) self, Vector3 target, float ratio)
    {
        var diff = target - self.position;
        var rot = Quaternion.LookRotation(diff) * Quaternion.Inverse(self.rotation);
        if (rot.w < 0) rot = rot.Reverse();

        return new Vector3(rot.x, rot.y, rot.z) * ratio;
    }
}
