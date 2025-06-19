using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public Collider playerCollider;
    public MeshRenderer playermeshrederer;
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
        /*addforce
         if (Input.GetKey(KeyCode.W)== true)
         {
             playerRigidbody.AddForce(0f, 0f, speed);
         }

         if (Input.GetKey(KeyCode.S) == true)
         {
             playerRigidbody.AddForce(0f, 0f, -speed);
         }

         if (Input.GetKey(KeyCode.A) == true)
         {
             playerRigidbody.AddForce(-speed, 0f, 0f);
         }

         if (Input.GetKey(KeyCode.D) == true)
         {
             playerRigidbody.AddForce(speed, 0f, 0f);
         }*/

    }
}
