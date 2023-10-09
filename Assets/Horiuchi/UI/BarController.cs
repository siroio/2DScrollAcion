using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_barObject;

    private BeatManager m_beatManager;

    private void Start()
    {

        m_beatManager = FindAnyObjectByType<BeatManager>();
        m_beatManager.OnBeat.AddListener(Spawn);
    }

    private void OnDestroy()
    {
        m_beatManager.OnBeat.RemoveListener(Spawn);
    }

    private void Spawn()
    {
        Instantiate(m_barObject, transform.parent);
    }
}
