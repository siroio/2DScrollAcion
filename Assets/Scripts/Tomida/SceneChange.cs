using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
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