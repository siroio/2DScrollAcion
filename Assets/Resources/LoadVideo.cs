using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
    VideoPlayer player;

    private void Start()
    {
        TryGetComponent(out player);
        player.clip = Resources.Load("bg") as VideoClip;
        player.Play();
    }
}
