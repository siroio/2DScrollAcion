using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : Singleton<BeatManager>
{
    public int BPM => m_BPM.Value;
    public float BPS => m_bps;
    public UnityEvent OnBeat { get => m_onBeat; set => m_onBeat = value; }
    public UnityEvent OnStartMusic { get => m_onBeat; set => m_onBeat = value; }

    [SerializeField]
    private UnityEvent m_onBeat;

    [SerializeField]
    private UnityEvent m_onStartMusic;

    [SerializeField, Label("ディレイ")]
    private float m_startDelay;

    [SerializeField, Label("曲のBPM")]
    private IntReactiveProperty m_BPM;

    private float m_timer;
    private float m_bps;
    private bool m_isEnable;

    private void Start()
    {
        m_BPM.ObserveEveryValueChanged(bpm => bpm.Value)
        .Subscribe(bpm => m_bps = ToSeconds(bpm))
        .AddTo(this);
        //TODO: タイミング調整
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(m_startDelay);
        StartBeatCount();
    }

    private static void StartBeatCount()
    {
        Instance.m_isEnable = true;
    }

    private static void StopBeatCount()
    {
        Instance.m_isEnable = false;
    }

    private void Update()
    {
        if (!m_isEnable) return;
        m_timer += Time.deltaTime;
        if (m_timer >= m_bps)
        {
            m_timer = 0;
            m_onBeat?.Invoke();
        }
    }

    private float ToSeconds(int BPM)
    {
        return (float)1 / (BPM / 60);
    }
}
