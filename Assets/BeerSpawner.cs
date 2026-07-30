using UnityEditor;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 7f;
    public float spawnRange = 7f;
    public float spawnY = 7f;
    public float fallingSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject),0f,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObject()
    {
       GameObject prefabs = prefab[Random.Range(0, prefab.Length)];

        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        GameObject spawnedObject = Instantiate(prefabs, spawnPosition, Quaternion.identity);
        
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();

        if(rb != null )
        {
            rb.linearVelocity = new Vector2(0, -fallingSpeed);
        }
    }
}
