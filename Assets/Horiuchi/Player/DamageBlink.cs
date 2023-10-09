using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{
    [SerializeField]
    private float BlinkSpeed;
    private IPlayer m_player;
    private bool m_isBlinking;
    private SpriteRenderer m_renderer;

    private void Start()
    {
        m_player = GetComponentInParent<IPlayer>();
        TryGetComponent(out m_renderer);
        m_player.OnTakeDamage.AddListener(StartBlinking);
    }

    private void OnDestroy()
    {
        m_player.OnTakeDamage.RemoveListener(StartBlinking);
    }

    public void StartBlinking()
    {
        if (m_isBlinking) return;
        m_isBlinking = true;
        StartCoroutine(Blink());
        StartCoroutine(StopBlinkDuratin());
    }

    private IEnumerator Blink()
    {
        while (m_isBlinking)
        {
            m_renderer.enabled = !m_renderer.enabled;
            yield return new WaitForSeconds(BlinkSpeed);
        }
        m_renderer.enabled = true;
    }

    private IEnumerator StopBlinkDuratin()
    {
        yield return new WaitForSeconds(m_player.InvincibleTime);
        m_isBlinking = false;
    }
}
