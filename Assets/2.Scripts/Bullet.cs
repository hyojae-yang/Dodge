using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
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
            if (playerController != null)
            {
                playerController.Hp--;
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
