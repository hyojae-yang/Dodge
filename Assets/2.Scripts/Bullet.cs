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
        Destroy(gameObject, 5f);
    }

    /*Color originColor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            originColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            float r = UnityEngine.Random.Range(0f, 1f);
            float g = UnityEngine.Random.Range(0f, 1f);
            float b = UnityEngine.Random.Range(0f, 1f);
            other.gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = originColor;
        }
    }*/
}
