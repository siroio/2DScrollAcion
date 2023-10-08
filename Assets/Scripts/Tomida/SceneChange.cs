using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //ゲームスタート
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    //ゲーム終了
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    //タイトルへ
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}