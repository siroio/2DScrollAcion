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
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    //ボタンをクリックした時
    public void OnClick()
    {
        audioSource.clip = SelectSE;
        audioSource.Play();
    }
}
