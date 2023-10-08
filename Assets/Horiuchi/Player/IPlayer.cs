using UnityEngine;
using UnityEngine.Events;

public interface IPlayer
{
    /// <summary>
    /// 体力
    /// </summary>
    /// <value>0 ~ 3</value>
    public uint Health { get; }
}
