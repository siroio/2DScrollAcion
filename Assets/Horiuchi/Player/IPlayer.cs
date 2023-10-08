public interface IPlayer
{
    public uint Health { get; }
    public uint Speed { get; }

    /// <summary>
    /// 移動時
    /// </summary>
    void OnMove();

    /// <summary>
    /// ビートのタイミング
    /// </summary>
    void OnBeat();
}
