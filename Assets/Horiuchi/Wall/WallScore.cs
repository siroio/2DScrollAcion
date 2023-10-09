using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScore : MonoBehaviour
{
    [SerializeField]
    private ScoreSO score;

    private bool ishit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ishit) return;
        ishit = true;
        score.Score += 100;
    }
}
