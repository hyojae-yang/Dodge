using UnityEngine;

public class Rotator : MonoBehaviour
{
   public float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f,rotationSpeed*Time.deltaTime,0f);
    }
}
