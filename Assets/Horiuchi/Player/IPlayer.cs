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
    /// 無敵時間
    /// </summary>
    public float InvincibleTime { get; }

    /// <summary>
    /// 移動時に呼び出されるイベント
    /// </summary>
    public UnityEvent MoveEvent { get; }

    /// <summary>
    /// ダメージを受けたときに呼び出されるイベント
    /// </summary>
    public UnityEvent OnTakeDamage { get; }

    /// <summary>
    /// 回復時に呼び出されるイベント
    /// </summary>
    public UnityEvent OnHeal { get; }

    /// <summary>
    /// 死亡時に呼び出されるイベント
    /// </summary>
    /// <value></value>
    public UnityEvent OnDeath { get; }

    /// <summary>
    /// 回復する
    /// </summary>
    /// <param name="value"></param>
    void Heal(uint value);

}
