using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードの種類
/// </summary>
public enum FadeType
{
    In,
    Out
}

public class ScreenFade : MonoBehaviour
{
    [SerializeField, Tooltip("UI")]
    private Graphic m_ui = default;

    [SerializeField, Tooltip("透明度")]
    private float m_alpha = default;

    [SerializeField, Tooltip("効果時間")]
    private float m_duration = default;

    [SerializeField, Tooltip("待機時間")]
    private float m_delay = default;

    [SerializeField, Tooltip("Start時に開始するか")]
    private bool m_onStartFade;

    [SerializeField, Tooltip("種類")]
    private FadeType m_fadeType = FadeType.In;
    private Tween m_fader;

    private void Start()
    {
        if (!m_onStartFade) return;
        StartFade(m_fadeType);
    }

    public void StartFade(FadeType type) => StartFade(type, m_duration, m_delay);
    public void StartFade(FadeType type, float duration, float delay, TweenCallback complete = null)
    {
        m_fader?.Kill();
        var endValue = type == FadeType.In ? 0 : m_alpha;
        m_fader = m_ui.DOFade(endValue, duration)
                    .SetDelay(delay)
                    .SetUpdate(true)
                    .OnComplete(complete);
    }
}
