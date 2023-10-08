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

    }
}
