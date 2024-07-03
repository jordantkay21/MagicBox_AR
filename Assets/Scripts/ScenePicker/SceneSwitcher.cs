using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    public void CloseMenu()
    {
        SceneManager.UnloadSceneAsync(4);
    }
}
