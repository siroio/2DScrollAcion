using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI meshPro;

    [SerializeField]
    private ScoreSO Score;

    private void Start()
    {
        meshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        meshPro.SetText(Score.Score.ToString("000000"));
    }
}
