using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshPro meshPro;

    [SerializeField]
    private ScoreSO Score;

    private void Start()
    {
        meshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        meshPro.text = Score.Score.ToString();
    }
}
