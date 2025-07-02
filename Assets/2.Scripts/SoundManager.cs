using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject sound;
    public GameObject sound2;
    private void Update()
    {
        Sound(sound,sound2);
    }

    public void Sound(GameObject sound,GameObject sound2)
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager.isGameOver == false)
        {
            sound.SetActive(false);
            sound2.SetActive(true);
        }

        else if (gameManager.isGameOver == true)
        { 
            sound.SetActive(true); 
            sound2.SetActive(false);
        }
    }
}
