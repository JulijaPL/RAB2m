using System.Collections;
using UnityEditor;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 2f;
    public float spawnRange = 10f;
    public float spawnY = 5f;
    public float fallingSpeed = 2f;

    public int spawnCount = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject),0f,spawnRate);
        StartCoroutine(SpawnRoutine());
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

            if (rb != null)
            {
                rb.linearVelocity = new Vector2(0, -fallingSpeed);
            }
        
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            int count = Random.Range(2, 5);

            for (int i = 0; i < count; i++)
            {
                SpawnObject();
                yield return new WaitForSeconds(1f);

            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }

    }
}
