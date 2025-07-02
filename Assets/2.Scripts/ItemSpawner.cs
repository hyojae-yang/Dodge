using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float spawnRatemin = 0.5f;
    public float spawnRatemax = 2f;
    private float spawnRate;
    private float timeAfterSpawn;
    GameManager gameManager;
    public GameObject terrainObject;
    float xSize;
    float zSize;
    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        xSize = terrainObject.GetComponent<BoxCollider>().size.x;
        zSize = terrainObject.GetComponent<BoxCollider>().size.z;
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
                float xResult = Random.Range(-xSize / 2, xSize / 2)*transform.localScale.x;
                float zResult = Random.Range(-zSize / 2, zSize / 2) * transform.localScale.z;
                GameObject item = Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], new Vector3(xResult,1, zResult), transform.rotation);
                
            }
        }
    }
}
