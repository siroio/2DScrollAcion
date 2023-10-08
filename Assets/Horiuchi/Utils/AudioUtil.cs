using UnityEngine;

public static class AudioUtil
{
    /// <summary>
    /// 0 ~ 1の音量をデシベルに変換する
    /// </summary>
    /// <param name="volume"> 0 - 1</param>
    /// <returns>float</returns>
    public static float ToDecibel(float volume)
        => Mathf.Clamp(Mathf.Log10(Mathf.Clamp01(volume)) * 20, -80f, 0f);

    /// <summary>
    /// decibelの音量を0 ~ 1に変換する
    /// </summary>
    /// <param name="decibel">decibel</param>
    /// <returns>float</returns>
    public static float ToVolume(float decibel)
        => Mathf.Clamp01(Mathf.Pow(10, Mathf.Clamp(decibel, -80f, 0) / 20f));
}
