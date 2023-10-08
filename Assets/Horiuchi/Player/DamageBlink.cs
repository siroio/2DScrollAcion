using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{
    [SerializeField]
    public float m_blinkDuration;
    private IPlayer m_player;
    private bool m_isBlinking;
    private float m_blinkTimer;
    private Renderer m_renderer;

    private void Start()
    {
        TryGetComponent(out m_player);
        TryGetComponent(out m_renderer);
        m_player.OnTakeDamage.AddListener(OnTakeDamage);
    }

    private void OnDestroy()
    {
        m_player.OnTakeDamage.RemoveListener(OnTakeDamage);
    }

    private void Update()
    {
        if (!m_isBlinking) return;
        m_blinkTimer += Time.deltaTime;

        // 点滅時間が終了したら点滅を停止する
        if (m_blinkTimer >= m_blinkDuration)
        {
            m_isBlinking = false;
            m_renderer.enabled = true; // レンダラーを再表示
        }
        else
        {
            // レンダラーを点滅させる
            m_renderer.enabled = !m_renderer.enabled;
        }
    }

    private void OnTakeDamage()
    {
        if (m_isBlinking) return;
        m_isBlinking = true;
        m_blinkTimer = 0.0f;
    }
}
