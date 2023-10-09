using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Wall : MonoBehaviour
{
    public float speed = -0.5f;
    public float duration = 0.1f;
    BeatManager beatManager;

    void Start()
    {
       
        beatManager = FindObjectOfType<BeatManager>();
        beatManager.OnBeat.AddListener(Move);
        //Sequence seq = DOTween.Sequence();
        //seq.Append(transform.DOMoveY(1, 3.5f).SetEase(Ease.Linear));
        //seq.Append(transform.DOMoveY(5, 3.5f).SetEase(Ease.Linear));
        //seq.SetLoops(-1, LoopType.Restart);

    }

   
    void Update()
    {
    }

    private void Move()
    {
        transform.DOMoveX(-speed, duration).SetRelative().SetEase(Ease.OutQuart);
    }
}
