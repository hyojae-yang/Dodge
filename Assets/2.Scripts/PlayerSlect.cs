using UnityEngine;

public class PlayerSlect : MonoBehaviour
{
    private void Awake()
    {
        transform.GetChild(GameManager.characterId).gameObject.SetActive(true);
    }
}
