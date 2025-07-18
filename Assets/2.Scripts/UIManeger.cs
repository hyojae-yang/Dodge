using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        GameManager.level = level;
    }
    public void GameStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameExit()
    { 
    Application.Quit();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true); 
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void SelectPlayer(int PlayerId)
    { 
        GameManager.characterId = PlayerId;

    }
}
