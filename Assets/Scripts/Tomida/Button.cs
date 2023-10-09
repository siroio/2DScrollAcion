using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float extRate = 1.5f;
    [SerializeField] float time = 0.2f;

    public AudioClip CursorSE;
    AudioSource audioSource;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    //カーソルがボタンに重なった時
    public void OnPointerEnter(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(extRate, extRate, 1), "time", time, "easeType", iTween.EaseType.easeOutBack));
        audioSource.clip = CursorSE;
        audioSource.Play();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", time, "easeType", iTween.EaseType.easeOutBack));
    }
}