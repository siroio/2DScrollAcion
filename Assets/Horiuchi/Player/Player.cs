using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IDamageable
{
    public uint Health { get => m_Health; }

    [SerializeField, Label("体力")]
    private uint m_Health;
    private Rigidbody2D m_rigidbody;

    private void Start()
    {
        TryGetComponent(out m_rigidbody);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_rigidbody.position += Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_rigidbody.position += Vector2.down;
        }
    }

    public void TakeDamage(uint damage)
    {
        m_Health = Math.Min(0, Health - Math.Clamp(damage, 0, 3));
    }
}
