using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IPlayer
{
    public uint Health => m_Health;
    public float InvincibleTime => m_invincibleTime;
    public UnityEvent MoveEvent => m_moveEvent;

    public UnityEvent OnTakeDamage => m_onTakeDamage;

    public UnityEvent OnHeal => m_onHeal;

    public UnityEvent OnDeath => m_onDeath;


    [SerializeField, Label("体力")]
    private uint m_Health;

    [SerializeField, Label("無敵時間")]
    private float m_invincibleTime;

    [SerializeField, Label("操作可能時間")]
    [Tooltip("BPMによる操作可能時間を秒数で指定")]
    private float m_duration;

    [SerializeField, Label("移動にかかる時間")]
    private float m_moveDuration;

    [SerializeField, Tooltip("移動時コールバック")]
    private UnityEvent m_moveEvent;

    [SerializeField, Tooltip("被ダメージ時コールバック")]
    private UnityEvent m_onTakeDamage;
    [SerializeField, Tooltip("回復時コールバック")]
    private UnityEvent m_onHeal;

    [SerializeField, Tooltip("死亡時コールバック")]
    private UnityEvent m_onDeath;

    [SerializeField, Label("移動補完方法")]
    private Ease m_moveEase;
    private float m_moveTimer;
    private float m_invincibleTimer;
    private bool isMove;
    private bool isDamaged;
    private Transform m_transform;
    private BeatManager m_beatManager;

    private void Start()
    {
        m_beatManager = FindAnyObjectByType<BeatManager>();
        TryGetComponent(out m_transform);
        m_beatManager.OnBeat.AddListener(ResetTimer);
    }

    private void OnDestroy()
    {
        m_beatManager.OnBeat.RemoveListener(ResetTimer);
    }

    private void Update()
    {
        m_moveTimer += Time.deltaTime;
        m_invincibleTimer += Time.deltaTime;
        if (m_invincibleTimer >= m_invincibleTime) isDamaged = false;
        if (m_moveTimer >= m_duration || isMove) return;
        OnMove();
    }

    private void ResetTimer()
    {
        isMove = false;
        m_moveTimer = 0;
    }

    private void OnMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMove = true;
            m_transform.DOMove(Vector3.up, m_moveDuration)
                .SetRelative(true)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isMove = true;
            m_transform.DOMove(Vector3.down, m_moveDuration)
                .SetRelative(true)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMove = true;
            m_transform.DOMove(Vector3.left, m_moveDuration)
                .SetRelative(true)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMove = true;
            m_transform.DOMove(Vector3.right, m_moveDuration)
                .SetRelative(true)
                .SetEase(m_moveEase);
        }
        if (isMove) m_moveEvent?.Invoke();
    }

    public void TakeDamage(uint damage)
    {
        if (isDamaged) return;
        damage = Math.Clamp(damage, 0, 3);
        m_invincibleTimer = 0;
        isDamaged = true;
        m_Health = Math.Max(0, m_Health - damage);
        m_onTakeDamage?.Invoke();
        if (m_Health <= 0) m_onDeath?.Invoke();
    }

    public void Heal(uint value)
    {
        m_Health = Math.Min(3, m_Health + Math.Clamp(value, 0, 1));
        m_onHeal?.Invoke();
    }
}
