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

    //�Q�[���X�^�[�g
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    //�Q�[���I��
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
    //�^�C�g����
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}