using System;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : Singleton<BeatManager>
{
    public uint BPM { get; }
    public UnityEvent OnBeat { get; set; }

    [SerializeField]
    private UnityEvent m_OnBeat;

    [SerializeField, Tooltip("曲のBPM")]
    private uint m_BPM;

    private float timer = 0.0f;

    private void Update()
    {
        if (timer >= ToSeconds(m_BPM))
        {
            timer = 0;
            m_OnBeat?.Invoke();
        }

        timer += Time.deltaTime;
    }

    float ToSeconds(uint BPM)
    {
        return (float)1 / (BPM / 60);
    }
}
