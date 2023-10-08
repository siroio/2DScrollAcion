using UnityEngine;
using System.Collections;

public class SelectSound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;

    public AudioClip SelectSE;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();

        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă��I�u�W�F�N�g�������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this);
        }
    }

    //�{�^�����N���b�N������
    public void OnClick()
    {
        audioSource.clip = SelectSE;
        audioSource.Play();
    }
}
