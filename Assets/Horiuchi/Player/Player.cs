using System;
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
    private float duration;

    [SerializeField, Label("移動時コールバック")]
    private UnityEvent m_moveEvent;

    [SerializeField, Label("被ダメージ時コールバック")]
    private UnityEvent m_onTakeDamage;
    [SerializeField, Label("回復時コールバック")]
    private UnityEvent m_onHeal;

    private float moveTimer;
    private bool isMove;
    private Rigidbody2D m_rigidbody;
    private BeatManager m_beatManager;

    private void Start()
    {
        TryGetComponent(out m_rigidbody);
        m_beatManager = FindAnyObjectByType<BeatManager>();
        m_beatManager.OnBeat.AddListener(ResetTimer);
    }

    private void OnDestroy()
    {
        m_beatManager.OnBeat.RemoveListener(ResetTimer);
    }

    private void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= duration || isMove) return;
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
            m_rigidbody.position += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isMove = true;
            m_rigidbody.position += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMove = true;
            m_rigidbody.position += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMove = true;
            m_rigidbody.position += Vector2.right;
        }
        if (isMove) m_moveEvent?.Invoke();
    }

    public void TakeDamage(uint damage)
    {
        damage = Math.Clamp(damage, 0, 3);
        if (Health > Health - damage) return;
        m_onTakeDamage?.Invoke();
        m_Health = damage;
    }

    public void Heal(uint value)
    {
        m_Health = Math.Min(3, m_Health + Math.Clamp(value, 0, 1));
        m_onHeal?.Invoke();
    }
}
