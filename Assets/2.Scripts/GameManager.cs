using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;

    float surviveTime = 0f;
    bool isGameOver;

    private void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        surviveTime = 0f;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "시간: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
   
    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);
        
        float BestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > BestTime)
        {
            BestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", BestTime);
        }
        recordText.text = "최고 기록: " + (int)BestTime;
        Time.timeScale = 0f;
    }
}
