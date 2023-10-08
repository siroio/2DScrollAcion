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
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    //�J�[�\�����{�^���ɏd�Ȃ�����
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.clip = CursorSE;
        audioSource.Play();
    }
}