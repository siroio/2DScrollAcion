using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class BarMover : MonoBehaviour
{
    [SerializeField]
    private GameObject right;

    [SerializeField]
    private GameObject left;

    private BeatManager m_beatManager;

    private void Start()
    {
        m_beatManager = FindAnyObjectByType<BeatManager>();
        Move();
    }

    private void LateUpdate()
    {
        if (right == null && left == null)
            Destroy(gameObject);
    }

    public void Move()
    {
        right.transform.DOMove(transform.position, m_beatManager.BPS)
            .OnKill(() => Destroy(right));
        left.transform.DOMove(transform.position, m_beatManager.BPS)
            .OnKill(() => Destroy(left));
    }
}
