using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_rigidbody.position += Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_rigidbody.position += Vector2.right;
        }
    }

    public void TakeDamage(uint damage)
    {
        m_Health = Math.Min(0, Health - Math.Clamp(damage, 0, 3));
    }

    public void Heal(uint value)
    {
        m_Health = Math.Min(3, m_Health + Math.Clamp(value, 0, 1));
    }
}
