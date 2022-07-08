using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void LoadGameScenePvP()
    {
        SceneManager.LoadScene(SceneNames.GameScenePvP);
    }
    public void LoadGameScenePvM()
    {
        SceneManager.LoadScene(SceneNames.GameScenePvM);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
}
