using DG.Tweening;
using UnityEngine;

public class BeatScaler : MonoBehaviour
{
    [SerializeField]
    private Vector3 MaxScale;

    [SerializeField]
    private float duration;

    private Transform m_Transform;
    private BeatManager m_BeatManager;

    private void Start()
    {
        TryGetComponent(out m_Transform);
        m_BeatManager = FindAnyObjectByType<BeatManager>();
        m_BeatManager.OnBeat.AddListener(DoPunchScale);
    }

    private void OnDestroy()
    {
        m_BeatManager.OnBeat.RemoveListener(DoPunchScale);
    }

    private void DoPunchScale()
    {
        m_Transform.DOPunchScale(MaxScale, duration, 1);
    }
}
