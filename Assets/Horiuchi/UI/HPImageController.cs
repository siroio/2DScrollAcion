using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPImageController : MonoBehaviour
{
    [SerializeField, Tooltip("HPの画像一覧")]
    private List<Image> m_hpImages;
    private IPlayer m_player;

    private void Start()
    {
        var obj = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in obj) p.TryGetComponent(out m_player);
        if (m_player.Health != m_hpImages.Count) Debug.LogError("HPの数が不一致です");
    }

    private void LateUpdate()
    {
        foreach (var image in m_hpImages)
        {
            image.enabled = false;
        }

        for (int i = 0; i < m_player.Health; i++)
        {
            m_hpImages[i].enabled = true;
        }
    }
}
