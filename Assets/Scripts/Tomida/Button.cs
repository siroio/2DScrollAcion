using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler
{
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
        audioSource.clip = CursorSE;
        audioSource.Play();
    }
}