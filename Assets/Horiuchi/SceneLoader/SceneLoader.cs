using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static async void LoadSceneAsync(string SceneName)
    {
        await LoadScene(SceneName);
    }

    private static async Task LoadScene(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }
    }
}
