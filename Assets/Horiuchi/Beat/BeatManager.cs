using System;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    public uint BPM { get; set; }
    public UnityEvent OnBeat { get; set; }

    private void Update()
    {

    }
}
