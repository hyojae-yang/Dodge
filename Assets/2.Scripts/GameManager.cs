using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;

    float suriveTime = 0f;
    bool isGameOver;

    private void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        suriveTime = 0f;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            suriveTime += Time.deltaTime;
            timeText.text = "시간: " + (int)suriveTime;
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
        if (suriveTime > BestTime)
        {
            BestTime = suriveTime;
            PlayerPrefs.SetFloat("BestTime", BestTime);
        }
        recordText.text = "최고 기록: " + (int)BestTime;
        Time.timeScale = 0f;
    }
}
