using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public float spawnRatemin = 0.5f;
    public float spawnRatemax = 2f;
    private float spawnRate;
    private float timeAfterSpawn;
    Transform target;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRatemin, spawnRatemax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        if (!gameManager.isGameOver)
        {
            timeAfterSpawn += Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;
                spawnRate = Random.Range(spawnRatemin, spawnRatemax);

                GameObject bullet = Instantiate(bulletPrefab[Random.Range(0, bulletPrefab.Length)], transform.position, transform.rotation);
                bullet.transform.LookAt(target);
                LevelArtBullet(bullet, GameManager.level);
            }
        }
    }
    void LevelArtBullet(GameObject levelBullet,int level)
    {
        levelBullet.GetComponent<Bullet>().speed += level * 4;
    }
}
