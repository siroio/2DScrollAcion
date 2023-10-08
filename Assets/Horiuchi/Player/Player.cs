using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IPlayer, IDamageable
{
    public uint Health { get; private set; }
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
        Health = Math.Min(0, Health - damage);
    }
}
