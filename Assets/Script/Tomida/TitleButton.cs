using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    //�Q�[���X�^�[�g
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("a");
    }
    //�Q�[���I��
    public void ChangeEndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}