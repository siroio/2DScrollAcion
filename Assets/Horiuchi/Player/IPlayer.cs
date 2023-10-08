using UnityEngine;
using UnityEngine.Events;

public interface IPlayer : IDamageable
{
    /// <summary>
    /// 体力
    /// </summary>
    /// <value>0 ~ 3</value>
    public uint Health { get; }

    /// <summary>
    /// 回復する
    /// </summary>
    /// <param name="value"></param>
    void Heal(uint value);
}
