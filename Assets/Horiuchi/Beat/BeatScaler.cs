using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScaler : MonoBehaviour
{
    private Transform m_Transform;
    private BeatManager m_BeatManager;

    private void Start()
    {
        TryGetComponent(out m_Transform);
        m_BeatManager = FindAnyObjectByType<BeatManager>();
    }
}
