using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnGameStartButtonClicked()
    {
        Invoke("GameStart", 1);
    }
    public void OnEndGameButtonClicked()
    {
        Invoke("EndGame", 1);
    }
    public void OnBackToTitleButtonClicked()
    {
        Invoke("BackToTitle", 1);
    }

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