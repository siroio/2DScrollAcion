using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IPlayer
{
    public uint Health => m_Health;
    public UnityEvent MoveEvent => m_moveEvent;

    public UnityEvent OnTakeDamage => m_onTakeDamage;

    public UnityEvent OnHeal => m_onHeal;

    [SerializeField, Label("体力")]
    private uint m_Health;

    [SerializeField, Label("操作可能時間")]
    [Tooltip("BPMによる操作可能時間を秒数で指定")]
    private float m_duration;

    [SerializeField, Label("移動にかかる時間")]
    private float m_moveDuration;

    [SerializeField, Label("移動時コールバック")]
    private UnityEvent m_moveEvent;

    [SerializeField, Label("被ダメージ時コールバック")]
    private UnityEvent m_onTakeDamage;
    [SerializeField, Label("回復時コールバック")]
    private UnityEvent m_onHeal;

    [SerializeField, Label("移動補完方法")]
    private Ease m_moveEase;
    private Tween m_moveTween;
    private float moveTimer;
    private bool isMove;
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
        moveTimer += Time.deltaTime;
        if (moveTimer >= m_duration || isMove) return;
        OnMove();
    }

    private void ResetTimer()
    {
        isMove = false;
        moveTimer = 0;
    }

    private void OnMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMove = true;
            m_transform.DOMove(m_transform.position + Vector3.up, m_moveDuration)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isMove = true;
            m_transform.DOMove(m_transform.position + Vector3.down, m_moveDuration)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMove = true;
            m_transform.DOMove(m_transform.position + Vector3.left, m_moveDuration)
                .SetEase(m_moveEase);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMove = true;
            m_transform.DOMove(m_transform.position + Vector3.right, m_moveDuration)
                .SetEase(m_moveEase);
        }
        if (isMove) m_moveEvent?.Invoke();
    }

    public void TakeDamage(uint damage)
    {
        damage = Math.Clamp(damage, 0, 3);
        if (Health <= (Health - damage)) return;
        m_onTakeDamage?.Invoke();
        m_Health = damage;
    }

    public void Heal(uint value)
    {
        m_Health = Math.Min(3, m_Health + Math.Clamp(value, 0, 1));
        m_onHeal?.Invoke();
    }
}
