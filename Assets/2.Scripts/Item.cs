using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public int speedpoint;
    public enum ItemType
    { 
        None,
        SpeedUp,
        Heal,
        isInvincible
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                switch (itemType)
                {
                    case ItemType.None:
                        break;
                    case ItemType.SpeedUp:
                        playerController.BuffSpeed(speedpoint);
                        break;
                    case ItemType.Heal:
                        playerController.BuffHp();
                        break;
                    case ItemType.isInvincible:
                        playerController.BuffisInvincible();
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
}
