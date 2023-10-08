using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : Singleton<BeatManager>
{
    public int BPM { get => m_BPM.Value; }
    public UnityEvent OnBeat { get => m_onBeat; set => m_onBeat = value; }

    [SerializeField]
    private UnityEvent m_onBeat;

    [SerializeField, Label("曲のBPM")]
    private IntReactiveProperty m_BPM;

    private float m_timer = 0.0f;
    private float m_bps;

    private void Start()
    {
        m_BPM.Subscribe((bpm) =>
        {
            m_bps = ToSeconds(bpm);
        });
    }

    private void Update()
    {
        if (m_timer >= m_bps)
        {
            m_timer = 0;
            m_onBeat?.Invoke();
        }

        m_timer += Time.deltaTime;
    }

    private float ToSeconds(int BPM)
    {
        return (float)1 / (BPM / 60);
    }
}
