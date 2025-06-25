using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody bulletRigdbody;

    private void Start()
    {
        bulletRigdbody = GetComponent<Rigidbody>();
        bulletRigdbody.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Hp--;
            if (playerController != null)
            {
                if (playerController.Hp <= 0)
                {
                    playerController.Hp = 0;
                    playerController.Die();
                }
                
            }
            Destroy(gameObject);
        }
        if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

}
