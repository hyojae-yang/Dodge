using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRatemin = 0.5f;
    public float spawnRatemax = 3f;
    private float spawnRate;
    private float timeAfterSpawn;
    Transform target;

    private void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRatemin, spawnRatemax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            spawnRate = Random.Range(spawnRatemin, spawnRatemax);
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
        }
        
    }
    
}
