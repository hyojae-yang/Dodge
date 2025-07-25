using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    private Animator playerAnimator;
    public float speed = 8f;
    public Collider playerCollider;
    public MeshRenderer playermeshrederer;
    public int Hp = 3;
    private bool isInvincible = false;
    private void Start()
    {
        //playerAnimator = GetComponentUnChildren<Animator>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true; // Prevent the player from tipping over
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        bool isMoving = (xInput !=0 || zInput !=0) ? true : false;
        playerAnimator.SetBool("isMove", isMoving);

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.linearVelocity = newVelocity;
    }
    
    public void Die(GameObject bulletTag)
    {
        if (isInvincible)
        {
            return;
        }
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (bulletTag.gameObject.tag == "Dibuff")
        {
            StartCoroutine(DibuffSlow());
            return;
        }
        Hp--;
        gameManager.HealthUpdate(Hp);
        if (Hp == 0)
        {
            gameManager.EndGame();
            gameObject.SetActive(false);
        }
    }
    IEnumerator DibuffSlow()
    {
        float originSpeed = speed;
        speed /= 2;
        yield return new WaitForSeconds(3f);
        speed = originSpeed;
    }
    public void BuffHp()
    {
        if (Hp < 6)
        { Hp++; }
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.HealthUpdate(Hp);
    }
    public void BuffSpeed(int speedpoint)
    {
        speed += speedpoint;
    }
    public void BuffisInvincible()
    {
        Transform buffEffect = transform.Find("Invincuble");
        if (buffEffect != null)
        {
            buffEffect.gameObject.SetActive(true);
        }
        isInvincible = true;
        Invoke("UnBuffisInvincible", 3f);
    }
    public void UnBuffisInvincible()
    {
        Transform buffEffect = transform.Find("Invincuble");
        if (buffEffect != null)
        {
            buffEffect.gameObject.SetActive(false);
        }
        isInvincible = false; 
    }
}
