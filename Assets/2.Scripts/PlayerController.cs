using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public Collider playerCollider;
    public MeshRenderer playermeshrederer;
    public int Hp = 3;
    public GameObject[] Hpicon;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true; // Prevent the player from tipping over
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.linearVelocity = newVelocity;
        
        if (Hp == 2)
        {
            Hpicon[2].SetActive(false);
        }
        else if (Hp == 1)
        {
            Hpicon[1].SetActive(false);
        }
        if (Hp == 0)
        {
            Hpicon[0].SetActive(false);
        }
    }
    
    public void Die()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
